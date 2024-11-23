
using MWAuth.MemoryData;

using CommonLib;


namespace MWAuth.BackgroundWokers
{
    public sealed class UserLoginWorker : BackgroundService
    {
        //private readonly ILoginService _loginService;

        //public UserLoginWorker(ILoginService loginService)
        //{
        //    _loginService = loginService;
        //}

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //Logger.log.Info($"[JOB CAP NHAT TRANG THAI USER LOGIN] Bat dau background service");

            //try
            //{
            //    //
            //    var userLogins = await c_loginClient.GetUserLoginStateAsync(string.Empty);

            //    LoginMem.InitUserLogin(userLogins);
            //}
            //catch (Exception ex)
            //{
            //    Logger.log.Error(ex, ex.Message);
            //}
            //
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    string guid = Utils.GenGuidStringN();
            //    DateTime startTime = DateTime.Now;

            //    Logger.log.Info($"[{guid}] [JOB CAP NHAT TRANG THAI USER LOGIN] Bat dau cap nhat trang thai user login");

            //    try
            //    {
            //        var tasks = new List<Task>()
            //        {
            //            GetCompany(),
            //            UpdateUserState(guid),
            //            ReloadUserSettings(guid),
            //        };

            //        await Task.WhenAll(tasks);
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.log.Error(ex, ex.Message);
            //    }

            //    Logger.log.Info($"[{guid}] [JOB CAP NHAT TRANG THAI USER LOGIN] Ket thuc cap nhat trang thai user login. Tong thoi gian {Logger.GetProcessingMilliseconds(startTime)}(ms)");

            //    await Task.Delay(2000, stoppingToken);
            //}
        }

        #region Private Functions 

        //private async Task UpdateUserState(string requestId)
        //{
        //    try
        //    {
        //        // Store user state
        //        var users = LoginMem.GetQueueUpdateUserLoginState();
        //        if (users != null && users.Count > 0)
        //        {
        //            await c_loginClient.UpdateUserLoginStateAsync(requestId, users);
        //        }

        //        // Get user state from DB to unlock User
        //        var savedUsers = await c_loginClient.GetUserLoginStateAsync(requestId);
        //        LoginMem.UpdateUserLockStatusFromDB(savedUsers);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.log.Error(ex, ex.Message);
        //    }
        //}

        #endregion
    }
}