using CommonLib.Constants;
using CommonLib.Extensions;
using Object.Core;
using Object.Core.Share;
using System.Collections.Concurrent;

namespace MWAuth.MemoryData
{
    public static class LoginMem
    {
        private static readonly object c_lock = new();
        /// <summary>
        /// Key: UserName; Value: List of Functions
        /// </summary>
        private static readonly ConcurrentDictionary<string, List<MWUserFunction>> c_dicFunctionsByUser = new();
        /// <summary>
        /// Key: UserName; Value: User
        /// </summary>
        private static readonly ConcurrentDictionary<string, MWUser> c_dicUser = new();
        /// <summary>
        /// Key: UserName; Value: LoggedUser
        /// </summary>
        private static readonly ConcurrentDictionary<string, LoggedUser> c_dicLoggedUser = new();
        /// <summary>
        /// Key: RefeshToken; Value: Info of RefeshToken
        /// </summary>
        private static readonly ConcurrentDictionary<string, IdentityRefreshToken> c_dicRefreshToken = new();

        /// <summary>
        /// Luu lai thong tin User va Ip de check so lan dang nhap loi
        /// </summary>
        private static readonly ConcurrentDictionary<string, MWUser> c_dicUserLoginByIp = new();
        private static readonly ConcurrentQueue<MWUser> c_queueUpdateUserLogin = new();
        private static int c_maximumLogonFailureCount = 5;
        private static int c_passwordExpiryDays = 30;

        #region Hanle Functions Of User

        public static void SetFunctions(string userId, List<MWUserFunction> userFunctions)
        {
            c_dicFunctionsByUser.AddOrUpdate(userId, userFunctions, (key, value) => userFunctions);
            RemoveCachedLoggedUser(userId);
        }

        public static List<MWUserFunction>? GetFunctionsByUserName(string userId)
        {
            List<MWUserFunction?> result = null;

            if (c_dicFunctionsByUser.TryGetValue(userId, out result)) return result;

            return null;
        }
        public static MWUserFunction? GetFunctionByUserName(string userId, string functionId)
        {
            List<MWUserFunction?> result = null;
            if (c_dicFunctionsByUser.TryGetValue(userId, out result))
            {
                return result.FirstOrDefault(x => string.Equals(functionId, x.FunctionId));
            }
            return null;
        }

        public static List<MWUserFunction>? GetFunctionByUserNameAndFunctionType(string userId, string functionType)
        {
            List<MWUserFunction?> result;

            if (c_dicFunctionsByUser.TryGetValue(userId, out result))
            {
                return result.Where(x => string.Equals(functionType, x.FunctionType))?.ToList();
            }

            return null;
        }

        public static bool ValidateFunctionPermission(string userId, string functionId, string action)
        {

            var functionsByUser = LoginMem.GetFunctionsByUserName(userId);
            var hasRight = false;

            if (functionsByUser != null && functionsByUser.Count > 0)
            {
                if (string.Equals(functionId, Const.AuthenFunctionId.Any, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                hasRight = functionsByUser.Any(x =>
                {

                    if (!string.Equals(functionId, x.FunctionId, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                    var valid = action switch
                    {
                        Const.AuthenAction.Any =>
                            string.Equals(x.AllowQuery, Const.YN.Yes)
                            || (string.Equals(x.AllowAdd, Const.YN.Yes))
                            || (string.Equals(x.AllowUpdate, Const.YN.Yes))
                            || (string.Equals(x.AllowDelete, Const.YN.Yes))
                            || (string.Equals(x.AllowExecute, Const.YN.Yes)),
                        Const.AuthenAction.Query => string.Equals(x.AllowQuery, Const.YN.Yes),
                        Const.AuthenAction.Add => (string.Equals(x.AllowAdd, Const.YN.Yes)),
                        Const.AuthenAction.Update => (string.Equals(x.AllowUpdate, Const.YN.Yes)),
                        Const.AuthenAction.Delete => (string.Equals(x.AllowDelete, Const.YN.Yes)),
                        Const.AuthenAction.Execute => (string.Equals(x.AllowExecute, Const.YN.Yes)),
                        _ => false
                    };

                    return valid;
                });
            }


            return hasRight;
        }

        public static bool ValidateFunctionPermission(string userId, string[] functionIds, string[] actions, string checkMode)
        {
            if (functionIds == null || functionIds.Length == 0 || actions == null || actions.Length == 0 || functionIds.Length != actions.Length)
            {
                return false;
            }

            if (string.Equals(checkMode, Const.AuthenCheckMode.All)
                || string.Equals(checkMode, Const.AuthenCheckMode.Any))
            {
                var checkResults = new bool[functionIds.Length];

                for (int i = 0; i < functionIds.Length; i++)
                {
                    checkResults[i] = ValidateFunctionPermission(userId, functionIds[i], actions[i]);
                }

                //
                if (string.Equals(checkMode, Const.AuthenCheckMode.All))
                {
                    return checkResults.All(x => x == true);
                }
                else
                {
                    return checkResults.Any(x => x == true);
                }
            }
            else
            {
                return ValidateFunctionPermission(userId, functionIds[0], actions[0]);
            }

        }

        #endregion

        #region Hanle Refresh Token

        public static void SetRefreshToken(IdentityRefreshToken refreshToken)
        {
            c_dicRefreshToken.AddOrUpdate(refreshToken.RefreshToken, refreshToken, (key, value) => refreshToken);
        }

        public static void RemoveRefreshToken(string refreshToken)
        {
            c_dicRefreshToken.Remove(refreshToken, out _);
        }

        public static IdentityRefreshToken? GetRefreshToken(string refreshToken)
        {
            IdentityRefreshToken? result = null;
            if (c_dicRefreshToken.TryGetValue(refreshToken, out result))
            {
                return result;
            }
            return null;
        }

        #endregion

        #region Hanle User

        public static void SetUser(MWUser user)
        {
            c_dicUser.AddOrUpdate(user.UserName, user, (key, value) => user);
            RemoveCachedLoggedUser(user.UserName);
        }

        public static MWUser? GetUser(string userId)
        {
            MWUser? result = null;
            if (c_dicUser.TryGetValue(userId, out result))
            {
                return result;
            }

            return null;
        }

        public static MWUser? GetUserByUserName(string userId)
        {
            if (c_dicUser.Count > 0)
            {
                foreach (var item in c_dicUser.Values)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (string.Equals(item.UserName, userId))
                    {
                        return item;
                    }
                }
            }
            return null;
        }


        public static LoggedUser GetLoggedUserFromUser(MWUser user)
        {
            var ret = c_dicLoggedUser.TryGetValue(user.UserName, out LoggedUser loggedUser);
            if (ret && loggedUser != null)
            {
                return loggedUser;
            }

            var functionsByUser = LoginMem.GetFunctionsByUserName(user.UserName);

            var storedUser = LoginMem.GetUser(user.UserName);

            var mustChangePassword = LoginMem.UserMustChangePassword(user.LastChangePasswordOn) || string.Equals(user.MustChangePasswordAtNextLogon, Const.YN.Yes);

            //loggedUser = new LoggedUser
            loggedUser = new LoggedUser
            {
                UserName = user.UserName,
                Name = user.Name,
                UserType = user.UserType,
                Status = user.Status,
                MustChangePassword = mustChangePassword,
                FunctionSettings = functionsByUser?.Select(x => new LoggedUserFunction
                {
                    FunctionId = x.FunctionId,
                    FunctionType = x.FunctionType,
                    AllowQuery = x.AllowQuery,
                    AllowAdd = x.AllowAdd,
                    AllowUpdate = x.AllowUpdate,
                    AllowDelete = x.AllowDelete,
                    AllowExecute = x.AllowExecute,
                }).ToList(),
                Clients = user.Clients,
                Freelancer = user.Freelancer,
            };

            c_dicLoggedUser.AddOrUpdate(user.UserName, loggedUser, (key, value) => loggedUser);
            return loggedUser;
        }

        private static string CalculateRight(string readOnlyUser, string right)
        {
            if (string.Equals(readOnlyUser, Const.YN.Yes))
            {
                return Const.YN.No;
            }

            return right;
        }

        private static void RemoveCachedLoggedUser(string userId)
        {
            c_dicLoggedUser.Remove(userId, out _);
        }

        public static void UpdateUserSettings(MWUser user)
        {
            if (user != null)
            {
                if (c_dicUser.ContainsKey(user.UserName))
                {
                    var storedUser = c_dicUser[user.UserName];
                    storedUser.FunctionSettings = user.FunctionSettings;
                }

                if (!c_dicFunctionsByUser.TryAdd(user.UserName, user.FunctionSettings))
                {
                    c_dicFunctionsByUser[user.UserName] = user.FunctionSettings;
                }
                RemoveCachedLoggedUser(user.UserName);
            }
        }

        #endregion

        #region User Login

        public static void InitUserLogin(List<MWUser> users)
        {
            c_dicUserLoginByIp.Clear();

            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    if (user == null || string.IsNullOrWhiteSpace(user.UserName))
                    {
                        continue;
                    }

                    c_dicUserLoginByIp[user.UserName.Trim().ToUpper() + "|" + user.LastTriedOrLogonIp] = user;
                }
            }
        }

        public static void UpdateUserLockStatusFromDB(List<MWUser> users)
        {
            var unlockedUsers = users?.Where(x => x is not null && !string.IsNullOrWhiteSpace(x.UserName) && !string.Equals(x.AccountIsLockedOut, Const.YN.Yes)).ToList();
            if (unlockedUsers is null || unlockedUsers.Count == 0)
            {
                return;
            }

            string[] keys = c_dicUserLoginByIp.Keys.ToArray();
            foreach (var user in unlockedUsers)
            {
                string[] keysByUserName = keys.Where(x => !string.IsNullOrWhiteSpace(x) && x.StartsWith(user.UserName.ToUpper() + "|")).ToArray();
                if (keysByUserName is null || keysByUserName.Length == 0)
                {
                    continue;
                }

                foreach (var key in keysByUserName)
                {
                    var tmpUser = c_dicUserLoginByIp[key];
                    tmpUser.AccountIsLockedOut = user.AccountIsLockedOut;
                    tmpUser.FailedLogonCount = user.FailedLogonCount;
                }
            }
        }

        public static void UpdateUserLoginState(string userId, string ip, bool isFailedLogin, out int failedLogonCount, out int maximumLogonFailureCount)
        {
            failedLogonCount = 0;
            maximumLogonFailureCount = c_maximumLogonFailureCount;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return;
            }

            userId = userId.Trim();
            ip = ip?.Trim() ?? string.Empty;

            var now = DateTime.Now;
            MWUser user = null;
            string userIdKey = userId.ToUpper() + "|" + ip;

            //
            if (c_dicUserLoginByIp.ContainsKey(userIdKey))
            {
                user = c_dicUserLoginByIp[userIdKey];
            }
            else
            {
                user = new()
                {
                    UserName = userId,
                };

                c_dicUserLoginByIp[userIdKey] = user;
            }

            //
            user.FailedLogonCount = isFailedLogin ? (user.FailedLogonCount + 1) : 0;
            user.LastTriedOrLogonTime = now;
            user.LastTriedOrLogonIp = ip;

            failedLogonCount = user.FailedLogonCount;

            // Neu User login nhieu lan sai thi se lock user
            if (user.FailedLogonCount >= c_maximumLogonFailureCount)
            {
                user.AccountIsLockedOut = Const.YN.Yes;

                // Lock tat ca thang dang login o IP khac nua
                string[] keys = c_dicUserLoginByIp.Keys.ToArray();
                if (keys != null && keys.Length > 0)
                {
                    foreach (var key in keys)
                    {
                        if (string.IsNullOrEmpty(key) || string.Equals(key, userIdKey) || !key.StartsWith(userId.ToUpper() + "|"))
                        {
                            continue;
                        }

                        var tmpUser = c_dicUserLoginByIp[key];
                        tmpUser.FailedLogonCount = user.FailedLogonCount;
                        tmpUser.LastTriedOrLogonTime = user.LastTriedOrLogonTime;
                        tmpUser.LastTriedOrLogonIp = user.LastTriedOrLogonIp;
                        tmpUser.AccountIsLockedOut = user.AccountIsLockedOut;
                    }
                }
            }
            else
            {
                user.AccountIsLockedOut = Const.YN.No;
            }

            //
            c_queueUpdateUserLogin.Enqueue(user.Clone());
        }

        public static bool AccountIsLockedOut(string userId, string ip)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            //string key = $"{userId?.Trim().ToUpper()}|{ip}";
            string[] keysByUserName = c_dicUserLoginByIp.Keys.Where(x => x?.StartsWith($"{userId?.Trim().ToUpper()}|") == true).ToArray();
            if (keysByUserName != null)
            {
                foreach (var key in keysByUserName)
                {
                    if (string.Equals(c_dicUserLoginByIp[key].AccountIsLockedOut, Const.YN.Yes))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool UserMustChangePassword(DateTime lastChangePasswordOn)
        {
            if (lastChangePasswordOn.Date != DateTime.MinValue.Date && DateTime.Now.Subtract(lastChangePasswordOn).TotalDays >= c_passwordExpiryDays)
            {
                return true;
            }

            return false;
        }

        public static List<MWUser> GetQueueUpdateUserLoginState()
        {
            if (!c_queueUpdateUserLogin.IsEmpty)
            {
                List<MWUser> users = new();
                for (int i = 0; i < c_queueUpdateUserLogin.Count; i++)
                {
                    var dequeueSuccess = c_queueUpdateUserLogin.TryDequeue(out var user);
                    if (dequeueSuccess && user != null)
                    {
                        users.Add(user);
                    }
                }

                return users;
            }

            return null;
        }

        #endregion

        #region Quản lý User cần reload lại thông tin do Cập nhật thông tin User/Role

        private static readonly List<string> _userIdsForReloadData = new();

        public static List<string> GetUserNamesForReloadData()
        {
            var userIds = new List<string>();

            if (_userIdsForReloadData != null)
            {
                userIds.AddRange(_userIdsForReloadData);
                _userIdsForReloadData.Clear();
            }

            return userIds;
        }

        #endregion
    }
}
