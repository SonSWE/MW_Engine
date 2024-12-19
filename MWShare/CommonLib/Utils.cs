using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CommonLib.Constants;

namespace CommonLib
{
    public static class Utils
    {
        private static readonly string _afAccNoAllowedChars = "0123456789";
        private static readonly Random _random = new();
        private static readonly string _emailExpression = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";

        public static string GenCustId()
        {
            StringBuilder sb = new();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(_afAccNoAllowedChars[_random.Next(0, _afAccNoAllowedChars.Length)]);
            }
            return sb.ToString();
        }
        public static string GenAFAccNo()
        {
            StringBuilder sb = new();
            for (int i = 0; i < 8; i++)
            {
                sb.Append(_afAccNoAllowedChars[_random.Next(0, _afAccNoAllowedChars.Length)]);
            }
            return sb.ToString();
        }
        //
        public static string GenGuidStringN()
        {
            return Utils.GenGuidString("N");
        }
        public static string GenGuidString(string format = "")
        {
            if (!string.IsNullOrEmpty(format))
            {
                return Guid.NewGuid().ToString(format);
            }
            return Guid.NewGuid().ToString();
        }
        //
        public static string SubString(string input, int startIndex)
        {
            return Utils.SubString(input, startIndex, (input?.Length ?? 0) - startIndex);
        }
        public static string SubString(string input, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(input)
                || startIndex < 0
                || startIndex >= input.Length
                || length <= 0
                )
            {
                return string.Empty;
            }

            length = Math.Min(length, input.Length - startIndex);

            //
            if (length > 0)
            {
                return input.AsSpan().Slice(startIndex, length).ToString();
            }
            return input.AsSpan().Slice(startIndex).ToString();
        }

        #region Hash

        private static readonly string _salt = "$2a$11$fWgLmvWL3PHc3klfvpeJWO";

        /// <summary>
        /// Create pass
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GeneratePassword(string password, string userName)
        {
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(userName))
                return BCrypt.Net.BCrypt.HashPassword(string.Format("{0};#{1}", password, userName.ToLower()), _salt);
            return string.Empty;
        }

        public static bool VerifyPassword(string userName, string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(string.Format("{0};#{1}", password, userName.ToLower()), hashedPassword);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Random string 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz";
            const string validUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string validNumber = "1234567890";
            const string validSymbol = "!?*.";
            StringBuilder res = new();

            res.Append(validUpper[RandomNumberGenerator.GetInt32(validUpper.Length)]);
            res.Append(validNumber[RandomNumberGenerator.GetInt32(validNumber.Length)]);
            res.Append(validSymbol[RandomNumberGenerator.GetInt32(validSymbol.Length)]);
            length -= 3;
            while (0 < length--)
            {
                res.Append(valid[RandomNumberGenerator.GetInt32(valid.Length)]);
            }
            return res.ToString();
        }
        //
        public static string ReplaceUnicodeString(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            Regex regex = new("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        //
        public static DateTime GetStartEndDateOfMonth(int year, int month, out DateTime endDate)
        {
            endDate = DateTime.MinValue;

            if (year < 1 || year > 9999 || month < 1 || month > 12) return DateTime.MinValue;

            DateTime startDate = new(year, month, 1);
            if (month == 12)
            {
                endDate = new DateTime(year, month, 31);
            }
            else
            {
                endDate = startDate.AddMonths(1).AddDays(-1);
            }

            return startDate;
        }
        public static DateTime GetStartEndDateOfQuarter(int year, int quarter, out DateTime endDate)
        {
            endDate = DateTime.MinValue;

            if (year < 1 || year > 9999 || quarter < 1 || quarter > 4) return DateTime.MinValue;

            DateTime startDate = new(year, ((quarter - 1) * 3) + 1, 1);
            if (quarter == 4)
            {
                endDate = new DateTime(year, 12, 31);
            }
            else
            {
                endDate = startDate.AddMonths(3).AddDays(-1);
            }

            return startDate;
        }
        public static DateTime GetStartEndDateOfYear(int year, out DateTime endDate)
        {
            endDate = DateTime.MinValue;

            if (year < 1 || year > 9999) return DateTime.MinValue;

            endDate = new DateTime(year, 12, 31);
            return new DateTime(year, 1, 1);
        }

        public static bool IsEmailAddress(string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            return (new Regex(_emailExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture, TimeSpan.FromSeconds(2))).IsMatch(value);
        }


        #region Convert DateTime sang Number, Number sang DateTime

        public static int DateToNumber(DateTime date)
        {
            _ = int.TryParse(date.ToString(Constants.Const.DateFormat.yyyyMMdd), out var dateInNumber);
            return dateInNumber;
        }

        public static DateTime DateFromNumber(int dateInNumber)
        {
            _ = DateTime.TryParseExact(dateInNumber.ToString("0").PadLeft(8, '0'), Constants.Const.DateFormat.yyyyMMdd, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date);
            return date;
        }

        public static int DateStringToNumber(string dateString, string format = "dd/MM/yyyy")
        {
            if (!string.IsNullOrEmpty(dateString) && DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return DateToNumber(dt);
            }
            return -1;
        }

        #endregion


        /// <summary>
        /// Hàm check chuỗi truyền vào có parse được sang datetime không
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsValidDate(string value, string format = "yyyyMMdd")
        {
            return DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
        }

        /// <summary>
        /// Hàm parse datetime sang từ dịnh dạng string truyền vào
        /// </summary>
        /// <param name="dateStr"></param>
        /// <param name="format"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ParseDate(string dateStr, out DateTime date, string format = "yyyyMMdd")
        {
            return DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        /// <summary>
        /// Hàm parse datetime sang từ dịnh dạng string truyền vào
        /// </summary>
        /// <param name="dateStr"></param>
        /// <param name="format"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ParseDate(string dateStr, string format, out DateTime date)
        {
            return DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        /// <summary>
        /// Check xem ngày hiện tại có phải ngày làm việc bình thường T2-T6
        /// </summary>
        /// <returns></returns>
        public static bool IsWorkingDay(DateTime dateTime)
        {
            // Check if the day of the week is Monday (0) to Friday (4)
            if (dateTime.DayOfWeek >= DayOfWeek.Monday && dateTime.DayOfWeek <= DayOfWeek.Friday)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra xem ngày nhập vào có phải là ngày cuối tuần không
        /// </summary>
        /// <returns></returns>
        public static bool IsWeekendDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Kiểm tra xem ngày nhập vào có lớn hơn ngày hiện tại không
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateAfterToday(DateTime date)
        {
            if (date <= DateTime.Now)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tính ngày làm việc theo khoảng ngày
        /// </summary>
        /// <param name="dateTime">Ngày giờ hiện tại</param>
        /// <param name="offDates">Danh sách ngày nghỉ</param>
        /// <param name="dayAdd">Ngày tiếp theo: 0 ngày hiện tại, 1 ngày tiếp theo, 2 cách 2 ngày .... </param>
        /// <returns></returns>
        public static DateTime GetNextWorkingDay(DateTime dateTime, List<DateTime> offDates, int dayAdd = 1)
        {
            // Kiểm tra nếu ngày hiện tại là ngày làm việc,
            // không phải thứ 6,
            // và ngày tiếp theo không thuộc ngày nghỉ
            if (IsWorkingDay(dateTime.AddDays(dayAdd)))
            {
                if (offDates != null && offDates.Contains(dateTime.AddDays(dayAdd)))
                {
                    return GetNextWorkingDay(dateTime.AddDays(dayAdd), offDates);
                }
                else
                {
                    return dateTime.AddDays(dayAdd);
                }
            }
            else
            {
                return GetNextWorkingDay(dateTime.AddDays(dayAdd), offDates);
            }
        }


        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }

        public static int CalculateAgeFromDate(DateTime dateToStart, DateTime dateOfBirth)
        {
            int age = dateToStart.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > dateToStart.AddYears(-age))
                age--;

            return age;
        }

        #region MyRegion

        public static bool StringContainsBothUpperAndLowerCase(string str)
        {
            return Regex.IsMatch(str, "((?=.*[a-z])(?=.*[A-Z]).*)");
        }

        public static bool StringContainsSpecialCharacter(string str)
        {
            return Regex.IsMatch(str, "[!@#$%^&*()_+\\-=\\[\\]{};':\\\"\\\\\\|,.<>\\/?~]");
        }

        /// <summary>
        /// String chỉ chứa số
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StringContainsNumber(string str)
        {
            return Regex.IsMatch(str, "[0-9]");
        }

        /// <summary>
        /// String chỉ chứa chữ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StringContainsCharacter(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        #endregion

        public static long ParseLongSpan(ReadOnlySpan<char> p_StringValue)
        {
            long _numberreturn;
            long.TryParse(p_StringValue, out _numberreturn);
            return _numberreturn;
        }

        public static string PadLeftChar0(string value, int totalWidth)
        {
            if (value.Length >= totalWidth)
            {
                return value;
            }
            return value.PadLeft(totalWidth, '0');
        }

        public static string FormatNumberWithSeparators(decimal number, string thousandSeparator = "", string decimalSeparator = "")
        {
            thousandSeparator = string.IsNullOrEmpty(thousandSeparator) ? Const.StringCharacters.Comma : thousandSeparator;
            decimalSeparator = string.IsNullOrEmpty(decimalSeparator) ? Const.StringCharacters.Dot : decimalSeparator;

            var numberFormatInfo = new NumberFormatInfo
            {
                NumberGroupSeparator = thousandSeparator,
                NumberDecimalSeparator = decimalSeparator
            };

            string formattedNumber =  number.ToString("N", numberFormatInfo);

            // Remove trailing zeros and the decimal separator if necessary
            if (formattedNumber.Contains(decimalSeparator))
            {
                formattedNumber = formattedNumber.TrimEnd('0').TrimEnd(decimalSeparator.ToCharArray());
            }

            return formattedNumber;
        }
    }

    public class RandomPassword
    {
        // Define default min and max password lengths.
        private static int DEFAULT_MIN_PASSWORD_LENGTH = 8;
        private static int DEFAULT_MAX_PASSWORD_LENGTH = 10;

        // Define supported password characters divided into groups.
        // You can add (or remove) characters to (from) these groups.
        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private static string PASSWORD_CHARS_NUMERIC = "23456789";
        private static string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        /// <summary>
        /// Generates a random password.
        /// </summary>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        /// <remarks>
        /// The length of the generated password will be determined at
        /// random. It will be no shorter than the minimum default and
        /// no longer than maximum default.
        /// </remarks>
        public static string Generate()
        {
            return Generate(DEFAULT_MIN_PASSWORD_LENGTH,
                            DEFAULT_MAX_PASSWORD_LENGTH);
        }

        /// <summary>
        /// Generates a random password of the exact length.
        /// </summary>
        /// <param name="length">
        /// Exact password length.
        /// </param>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        public static string Generate(int length)
        {
            return Generate(length, length);
        }

        /// <summary>
        /// Generates a random password.
        /// </summary>
        /// <param name="minLength">
        /// Minimum password length.
        /// </param>
        /// <param name="maxLength">
        /// Maximum password length.
        /// </param>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        /// <remarks>
        /// The length of the generated password will be determined at
        /// random and it will fall with the range determined by the
        /// function parameters.
        /// </remarks>
        public static string Generate(int minLength, int maxLength)
        {
            // Make sure that input parameters are valid.
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                return null;

            // Create a local array containing supported password characters
            // grouped by types. You can remove character groups from this
            // array, but doing so will weaken the password strength.
            char[][] charGroups = new char[][]
            {
            PASSWORD_CHARS_LCASE.ToCharArray(),
            PASSWORD_CHARS_UCASE.ToCharArray(),
            PASSWORD_CHARS_NUMERIC.ToCharArray(),
            PASSWORD_CHARS_SPECIAL.ToCharArray()
            };

            // Use this array to track the number of unused characters in each
            // character group.
            int[] charsLeftInGroup = new int[charGroups.Length];

            // Initially, all characters in each group are not used.
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            // Use this array to track (iterate through) unused character groups.
            int[] leftGroupsOrder = new int[charGroups.Length];

            // Initially, all character groups are not used.
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            // Because we cannot use the default randomizer, which is based on the
            // current time (it will produce the same "random" number within a
            // second), we will use a random number generator to seed the
            // randomizer.

            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            // Convert 4 bytes into a 32-bit integer value.
            int seed = BitConverter.ToInt32(randomBytes, 0);

            // Now, this is real randomization.
            Random random = new Random(seed);

            // This array will hold password characters.
            char[] password = null;

            // Allocate appropriate memory for the password.
            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];

            // Index of the next character to be added to password.
            int nextCharIdx;

            // Index of the next character group to be processed.
            int nextGroupIdx;

            // Index which will be used to track not processed character groups.
            int nextLeftGroupsOrderIdx;

            // Index of the last non-processed character in a group.
            int lastCharIdx;

            // Index of the last non-processed group.
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            // Generate password characters one at a time.
            for (int i = 0; i < password.Length; i++)
            {
                // If only one character group remained unprocessed, process it;
                // otherwise, pick a random character group from the unprocessed
                // group list. To allow a special character to appear in the
                // first position, increment the second parameter of the Next
                // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);

                // Get the actual index of the character group, from which we will
                // pick the next character.
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                // Get the index of the last unprocessed characters in this group.
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                // If only one unprocessed character is left, pick it; otherwise,
                // get a random character from the unused character list.
                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                // Add this character to the password.
                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                // If we processed the last character in this group, start over.
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;
                // There are more unprocessed characters left.
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[nextGroupIdx]--;
                }

                // If we processed the last group, start all over.
                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                // There are more unprocessed groups left.
                else
                {
                    // Swap processed group with the last unprocessed group
                    // so that we don't pick it until we process all groups.
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    // Decrement the number of unprocessed groups.
                    lastLeftGroupsOrderIdx--;
                }
            }

            // Convert password characters into a string and return the result.
            return new string(password);
        }

        
    }
}
