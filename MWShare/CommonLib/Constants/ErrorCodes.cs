namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {

        public const int Success = 1;
        //
        public const int Err_Unknown = -1;
        public const int Err_Exception = -2;
        public const int Err_NotFound = -3;
        public const int Err_Existed = -4;
        public const int Err_InvalidData = -5;
        public const int Err_InvalidArgument = -6;
        public const int Err_DataNull = -7;
        public const int Err_Undefined = -8;
        public const int Err_ChildData = -9;
        public const int Err_ApproveUserSameCreateUser = -10;
        public const int Err_CancelUserSameCreateUser = -11;
        public const int Err_CancelReasonNull = -12;
        public const int Err_DerivativeNotAllowProcessingInBatch = -13;

        //
        public static bool IsCommonError(long errorCode)
        {
            switch (errorCode)
            {
                case Err_Unknown:
                case Err_Exception:
                case Err_NotFound:
                case Err_Existed:
                case Err_InvalidData:
                case Err_InvalidArgument:
                case Err_DataNull:
                case Err_Undefined:
                case Err_ChildData:
                case Err_ApproveUserSameCreateUser:
                case Err_CancelUserSameCreateUser:
                case Err_CancelReasonNull:
                    return true;
                default:
                    return false;
            }
        }

        public static partial class ErrorDataType
        {
            public const string Success = "S";
            //
            public const int Err_Int = -1;
            public const int Err_Long = -2;
            public const int Err_Double = -3;
            public const int Err_Enum = -4;
            public const int Err_Datetime = -5;
            public const int Err_Bool = -6;
            public const int Err_Exception = -7;
            public const int Err_DataNull = -8;
            public const int Err_Decimal = -9;


            //
            public static bool IsCommonError(long errorCode)
            {
                switch (errorCode)
                {
                    case Err_Int:
                    case Err_Long:
                    case Err_Double:
                    case Err_Decimal:
                    case Err_Enum:
                    case Err_Datetime:
                    case Err_Bool:
                    case Err_Exception:
                    case Err_DataNull:
                        return true;
                    default:
                        return false;
                }
            }

            public static string GetErrorDesc(long errorCode, string language)
            {
                bool isEn = language?.Equals("EN", System.StringComparison.OrdinalIgnoreCase) == true;

                switch (errorCode)
                {
                    case Err_Int: return isEn ? "Must be numeric" : "Dữ liệu phải là kiểu số";
                    case Err_Long: return isEn ? "Must be numeric" : "Dữ liệu phải là kiểu số";
                    case Err_Double: return isEn ? "Must be numeric" : "Dữ liệu phải là kiểu số";
                    case Err_Decimal: return isEn ? "Must be numeric" : "Dữ liệu phải là kiểu số";
                    case Err_Enum: return isEn ? "Must be true/false" : "Dữ liệu phải là kiểu true/false";
                    case Err_Datetime: return isEn ? "Must be date string dd/MM/yyyy" : "Dữ liệu phải là kiểu DateTime dd/MM/yyyy";
                    case Err_Bool: return isEn ? "Must be boolean" : "Dữ liệu phải là kiểu bool";
                    case Err_Exception: return isEn ? "Exception" : "Lỗi ngoại lệ";
                    case Err_DataNull: return isEn ? "Cannot be empty" : "Không được để trống";
                    default:
                        break;
                }

                return "-";
            }
        }
    }
}
