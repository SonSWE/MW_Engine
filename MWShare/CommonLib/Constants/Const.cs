using System;

namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class DateFormat
        {
            public const string yyyyMMdd = "yyyyMMdd";
            public const string yyyyMMdd_Hyphens = "yyyy-MM-dd";
            public const string yyyyMMdd_Slash = "yyyy/MM/dd";
            public const string yyMMdd = "yyMMdd";

            public const string ddMMyyyy = "ddMMyyyy";
            public const string ddMMyyyy_Hyphens = "dd-MM-yyyy";
            public const string ddMMyyyy_Slash = "dd/MM/yyyy";

            public const string yyyyMMddHHmmss = "yyyyMMddHHmmss";
        }

        public static class TimeFormat
        {
            public const string HHmmss = "HHmmss";
            public const string HHmmss_Colon = "HH:mm:ss";

            public const string HHmm = "HHmm";
            public const string HHmm_Colon = "HH:mm";
        }


        public static class Action
        {
            public const string Add = "A";
            public const string Update = "U";
            public const string Delete = "D";
            public const string Convert = "CV";
            public const string Cancel = "C";
            public const string Approve = "AP";
            public const string Reject = "R";
            public const string Release = "RL";
            public const string Process = "PS";

            public static bool IsAdd(string action) => string.Equals(action, Action.Add);
            public static bool IsUpdate(string action) => string.Equals(action, Action.Update);
            public static bool IsDelete(string action) => string.Equals(action, Action.Delete);
        }

        public static class ONLINE_STATUS
        {
            public const string Online = "ON";
            public const string Offline = "OFF";
        }

        public static class YN
        {
            public const string Yes = "Y";
            public const string No = "N";

            public static bool IsYes(string value)
            {
                switch (value)
                {
                    case Yes:
                        return true;
                    default:
                        return false;
                }
            }

            public static bool IsValidate(string value)
            {
                return value == Yes || value == No;
            }
        }

        // 
        public static class Search
        {
            public static class Operator
            {
                public const string LessThan = "<";
                public const string LessThanOrEqual = "<=";
                public const string Equal = "=";
                public const string GreaterThanOrEqual = ">=";
                public const string GreaterThan = ">";
                public const string Like = "LIKE";
                public const string In = "IN";

                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(LessThan, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(LessThanOrEqual, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(Equal, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(GreaterThanOrEqual, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(GreaterThan, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(Like, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(In, StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        return true;
                    }
                    return false;
                }
            }

            public static class DataType
            {
                public const string String = "STR";
                public const string Int = "INT";
                public const string Long = "LNG";

                /// <summary>
                /// #,##0.#
                /// </summary>
                public const string Double = "DBL";
                /// <summary>
                /// #,##0
                /// </summary>
                public const string Double0 = "DBL0";
                /// <summary>
                /// #,##0.#
                /// </summary>
                public const string Double1 = "DBL1";
                /// <summary>
                /// #,##0.##
                /// </summary>
                public const string Double2 = "DBL2";
                /// <summary>
                /// #,##0.###
                /// </summary>
                public const string Double3 = "DBL3";
                /// <summary>
                /// #,##0.####
                /// </summary>
                public const string Double4 = "DBL4";

                /// <summary>
                /// dd/MM/yyyy
                /// </summary>
                public const string Date = "DAT";
                /// <summary>
                ///  dd/MM/yyyy
                /// </summary>
                public const string Date10 = "DAT10";
                /// <summary>
                ///  dd/MM/yyyy HH:mm
                /// </summary>
                public const string Date16 = "DAT16";
                /// <summary>
                /// dd/MM/yyyy HH:mm.ss
                /// </summary>
                public const string Date19 = "DAT19";
                /// <summary>
                /// dd/MM/yyyy HH:mm:ss.fff
                /// </summary>
                public const string Date23 = "DAT23";
                /// <summary>
                /// yyyyMMdd store in Number
                /// </summary>
                public const string DateNumber = "DATNUM";

                public const string JsonArray = "JARR";

                public static bool IsDateDataType(string dataType)
                {
                    switch (dataType)
                    {
                        case Date:
                        case Date10:
                        case Date16:
                        case Date19:
                        case Date23:
                            return true;
                        default:
                            return false;
                    }
                }
            }

            public static class Display
            {
                public const string Yes = "Y";
                public const string No = "N";
                public const string Hidden = "H";
                public const string Export = "E";
            }

            public static class Align
            {
                public const string Left = "L";
                public const string Center = "C";
                public const string Right = "R";
            }

            public static class Fixed
            {
                public const string Left = "L";
                public const string Right = "R";
            }

            public static class Control
            {
                public const string ComboSingle = "CBS";
                public const string ComboMultiple = "CBM";
                public const string Date = "DAT";
                public const string Date10 = "DAT10";
                public const string Date16 = "DAT16";
                public const string Date19 = "DAT19";
                public const string Date23 = "DAT23";
                public const string Date_Range = "DAT_RNG";
                public const string Date10_Range = "DAT10_RNG";
                public const string Date16_Range = "DAT16_RNG";
                public const string Date19_Range = "DAT19_RNG";
                public const string Date23_Range = "DAT23_RNG";
                public const string Long_Range = "LNG_RNG";
                public const string Double_Range = "DBL_RNG";
            }

            public static class SortDirection
            {
                public const string Default = "";
                public const string Asc = "ASC";
                public const string Desc = "DESC";

                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(Asc, StringComparison.OrdinalIgnoreCase)
                        || value.Equals(Desc, StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        return true;
                    }
                    return false;
                }
            }

            public static class PassCondAsArray
            {
                public const string No = "N";
                public const string Yes = "Y";
                public const string Optimize = "O";
            }

            public static class UserRightParam
            {
                public const string TranCode = "UR___TRANCODE";
                public const string MtCode = "UR___MTCODE";
                public const string ApiName = "UR___APINAME";
                public const string RptCode = "UR___RPTCODE";
                public const string BranchIds = "UR___BRANCHIDS";

                public static bool IsValid(string param)
                {
                    return param switch
                    {
                        TranCode or MtCode or ApiName or RptCode or BranchIds => true,
                        _ => false,
                    };
                }
            }

            public static class FieldName
            {
                public const string No = "NO";
                public const string TotalRecord = "TOTAL___RECORD";
            }
        }

        //

        public static class AuthenFunctionId
        {

            public const string Any = "ANY";
            public const string SystemCode = "SystemCode";
            public const string SysParam = "SysParam";
            public const string Job = "JOB";
            public const string Skill = "SKILL";

        }

        public static class AuthenAction
        {
            public const string Any = "ANY";
            public const string Query = "QUERY";
            public const string Add = "ADD";
            public const string Update = "UPDATE";
            public const string Delete = "DELETE";
            public const string Cancel = "CANCEL";
            public const string Execute = "EXECUTE";
            public const string ApproveAdd = "APPROVEADD";
            public const string ApproveUpdate = "APPROVEUPDATE";
            public const string ApproveDelete = "APPROVEDELETE";
            public const string ApproveExecute = "APPROVEEXECUTE";
            public const string Backdate = "BACKDATE";
            public const string Notification = "NOTIFICATION";
            public const string Import = "IMPORT";
            public const string Export = "EXPORT";
            public const string Print = "PRINT";
            public const string CheckAccessHierachy = "CHECKACCESSHIERACHY";
            public const string CopyRecord = "COPYRECORD";
        }

        public static class AuthenCheckMode
        {
            public const string Single = "Single";
            public const string Any = "Any";
            public const string All = "All";
        }


        public static class InputSettingAutoId
        {
            //1 	Có thể xem và thay đổi cài đặt margin cho Mã Chứng Khoán ở màn hình Instrument Can View And Change Margin Settings For Instrument
            //2 	Có thể nhập khoản vay lớn hơn số tiền vay tối đa                                    Can Input loan which greater than maximum borrow amount
            //3 	Có thể tạo giao dịch rút chứng khoán có số lượng > Số dư khả dụng                   Can Input Stock Withdraw > Max.With.Bal.
            //4 	Có thể nhập giao dịch ngày tương lai                                                Can Input Future Date Transaction
            //5 	Có thể nhập giao dịch hưởng quyền mà không cần  phân bổ                             Can Input Entitlement Transaction With No Distribution Option
            //6 	Có thể nhập giao dịch hưởng quyền mà không cần tùy chọn khấu trừ                    Can Input Entitlement Transaction With No Deduction Option
            //7 	Có thể nhập giao dịch hưởng quyền khi không đủ sức mua                              Can Input Entitlement Transaction When Not Enough Purchasing Power
            //8 	Có thể nhập giao dịch rút tiền vượt hạn mức chặn rút tiền Can Input Cash WithDrawal Excess Stop Withdrawal Ratio
            //9 	Có thể nhập giao dịch rút tiền vượt EE cho tài khoản khác tài khoản margin          Can Input Cash Withdrawal > Max.With.Bal. for Non Margin Account
            //10	Có thể nhập giao dịch rút tiền vượt EE cho tài khoản margin Can Input Cash Withdrawal > Max.With.Bal. for Margin Account
            //11	Có thể nhập giao dịch rút tiền vượt số dư tài khoản ngân hàng                       Can Input Cash Withdrawal > Bank.Bal.
            //12	Có thể nhập giao dịch rút tiền > số dư khả dụng cho tài khoản khác tài khoản margin Can Input Cash Withdrawal > Avail.Bal. for Non Margin Account
            //13	Có thể nhập giao dịch rút tiền > số dư khả dụng cho tài khoản margin                Can Input Cash Withdrawal > Avail.Bal. for Margin Account
            //14	Có thể nhập giao dịch rút tiền cho tài khoản mapbank Can Input Cash Transaction for cash at bank(mapbank) account
            //15	Có thể nhập giao dịch cho ngày quá khứ Can Input Back date Transaction
            //16	Có thể thay đổi loại tài khoản mặc dù xác thực không thành công                     Can Change Account Type Even Validation Fail
            //17	Có thể thay đổi thông tin tài khoản cho tài khoản đã đóng Can Change Account Information For Closed Account
            /// <summary>
            /// 18	Có thể tạo giao dịch Nộp tiền ký quỹ không check số dư (Can Make Deposit IM No Checking Balance)
            /// </summary>
            public const long CanMakeDepositIMNoCheckingBalance = 18;
            /// <summary>
            /// 19	Hạn mức nhập cho Deposit IM (Deposit IM Limit)
            /// </summary>
            public const long DepositIMLimit = 19;
            /// <summary>
            /// 20	Hạn mức nhập cho Withdraw IM (Withdraw IM Limit)
            /// </summary>
            public const long WithdrawIMLimit = 20;
            /// <summary>
            /// 21	Hạn mức nhập cho PaymentST (Payment IM Limit)
            /// </summary>
            public const long PaymentSTLimit = 21;
            /// <summary>
            /// 22	Hạn mức nhập cho Extra Credit Maintenance 
            /// </summary>
            public const long ExtraCreditMaintenanceLimit = 22;
        }

        public static class ProfileKeyField
        {

            public const string SystemCode = "SystemCodeId";
            public const string Job = "JobId";
            public const string Proposal = "ProposalId";
            public const string Contract = "ContractId";
            public const string ContractResult = "ContractResultId";
            public const string Feedback = "FeedBackId";
            public const string SysParam = "SysParamId";
            public const string JobSkill = "SkillId";
            public const string Skill = "SkillId";
            public const string Specialty = "SpecialtyId";
            public const string User = "UserName";
            public const string Freelancer = "FreelancerId";
            public const string Client = "ClientId";
            public const string Wallet = "WalletId";
            public const string Transaction = "TransactionId";



        }

        public static class SysParam_Grp
        {
            public const string System = "SYSTEM";
            public const string SystemFee = "SYSTEM_FEE";
            public const string SystemCot = "SYSTEM_COT";
            public const string ORDER_CHECKING_GROUP = "ORDER_CHECKING_GROUP";
        }

        public static class SysParam_Name
        {
            public const string Member = "MEMBER";
            public const string DepositIM = "DEPOSIT_IM";
            public const string WithdrawIM = "WITHDRAW_IM";
            public const string CotBank = "COT_BANK";
            public const string CotVSD = "COT_VSD";
            public const string POSITION_LIMIT_GROUP_INDIVIDUAL = "POSITION_LIMIT_GROUP_INDIVIDUAL";
            public const string ORDER_CHECKING_GROUP_INDIVIDUAL = "ORDER_CHECKING_GROUP_INDIVIDUAL";
            public const string POSITION_LIMIT_GROUP_ORGANIZE = "POSITION_LIMIT_GROUP_ORGANIZE";
            public const string ORDER_CHECKING_GROUP_ORGANIZE = "ORDER_CHECKING_GROUP_ORGANIZE";
        }



        public static class DbTable
        {
            public const string MWMessage = "MWMessage";
            public const string MWResult = "MWResult";

            public const string MWSkill = "MWSkill";
            public const string MWAccount = "MWAccount";
            public const string MWFreelancer = "MWFreelancer";
            public const string MWFreelancerSkill = "MWFreelancerSkill";
            public const string MWFreelancerSpecialty = "MWFreelancerSpecialty";
            public const string MWFreelancerEducation = "MWFreelancerEducation";
            public const string MWFreelancerWorkingHistory = "MWFreelancerWorkingHistory";
            public const string MWFreelancerCertificate = "MWFreelancerCertificate";
            
            public const string MWProposal = "MWProposal";
            public const string MWContract = "MWContract";
            public const string MWContractResult = "MWContractResult";
            public const string MWProposalFileAttach = "MWProposalFileAttach";
            public const string MWFeedBack = "MWFeedBack";
            public const string MWClient = "MWClient";
            public const string MWFeedBackImage = "MWFeedBackImage";
            public const string MWWallet = "MWWallet";
            public const string MWTransaction = "MWTransaction";
            public const string MWJobSkill = "MWJobSkill";
            public const string MWJobSaved = "MWJobSaved";
            public const string MWSysParam = "MWSysParam";
            public const string MWSystemCode = "MWSystemCode";
            public const string MWSystemCodeValue = "MWSystemCodeValue";
            public const string MWJob = "MWJob";
            public const string MWJobFileAttach = "MWJobFileAttach";
            public const string MWFileAttach = "MWFileAttach";
            public const string MWCategory = "MWCategory";
            public const string MWSpecialty = "MWSpecialty";
            public const string MWFunction = "MWFunction";
            public const string MWUserFunction = "MWUserFunction";
            public const string MWUser = "MWUser";
            public const string MWSearch = "MWSearch";
            public const string MWSaveJob = "MWSaveJob";


        }

        public static class SeqTable
        {
            public const string skill = "seq_mwskill";
            public const string specialty = "seq_mwspecialty";
        }

        public static class SystemCodeId
        {
            public const string Market = "MARKET";
            public const string ProductClass = "PRODUCTCLASS";
            public const string ForProductClass = "FORPRODUCTCLASS";
            public const string TransactionCodeType = "TRANSACTIONCODETYPE";
            public const string TransactionCatalog_Cash = "TRANSACTIONCATALOG_CASH";
            public const string TransactionCatalog_Instrument = "TRANSACTIONCATALOG_INSTRUMENT";
            public const string FeeClassType = "FEECLASSTYPE";
            public const string InvestorType = "INVESTORTYPE";
            public const string Status = "STATUS";
            public const string REGISTRATIONTYPE = "REGISTRATIONTYPE";
            public const string MARKET_DAYOFFSET = "MARKET_DAYOFFSET";
            public const string TradeType = "TRADETYPE";
            public const string SYS_YN = "SYS_YN";
            public const string SYS_YN_NONE = "SYS_YN-";
            public const string GENDER = "GENDER";
            public const string SYS_COUNTRY = "SYS_COUNTRY";
            public const string SYS_NATIONALITY = "SYS_NATIONALITY";
            public const string SYS_PROVINCE = "SYS_PROVINCE";

            public const string ROLE_STATUS = "ROLE_STATUS";

            public const string USER_USERTYPE = "USER_USERTYPE";
            public const string USER_STATUS = "USER_STATUS";
            public const string USER_POSITION = "USER_POSITION";
            public const string BranchType = "BRANCHTYPE";

            public const string LOCATION_LOCATIONTYPE = "LOCATION_LOCATIONTYPE";

            public const string MASTERDATA_RECORDSTATUS = "MASTERDATA_RECORDSTATUS";

            public const string ACCOUNTEXECUTIVE_AETYPE = "ACCOUNTEXECUTIVE_AETYPE";

            public const string SUBSTATUS_DATATYPE = "SUBSTATUS_DATATYPE";

            public const string BANKACCOUNTDETAIL_USAGETYPE = "BANKACCOUNTDETAIL_USAGETYPE";
            public const string BANKACCOUNTDETAIL_FUNDINGTYPE = "BANKACCOUNTDETAIL_FUNDINGTYPE";

            public const string CALENDAR_DATETYPE = "CALENDAR_DATETYPE";

            public const string ConnectionMethod = "CONNECTIONMETHOD";

            public const string COMPANY_DATEFORMAT = "COMPANY_DATEFORMAT";
            public const string Separator = "SEPARATOR";

            public const string FEE_DIVISORTYPE_ANNUALLY = "FEE_DIVISORTYPE_ANNUALLY";
            public const string FEE_DIVISORTYPE_MONTHLY = "FEE_DIVISORTYPE_MONTHLY";
            public const string FEE_DIVISORTYPE_QUARTERLY = "FEE_DIVISORTYPE_QUARTERLY";
            public const string FEE_DIVISORTYPE_SEMI_ANNUALLY = "FEE_DIVISORTYPE_SEMI_ANNUALLY";

            public const string TRADINGSESSION_MATCHTYPE = "TRADINGSESSION_MATCHTYPE";

            public const string TRADINGTIMETABLE_TTYPE = "TRADINGTIMETABLE_TTYPE";
            public const string TRADINGTIMETABLE_EORO = "TRADINGTIMETABLE_EORO";

            public const string TRANSACTIONCODE_TRANSACTIONCODETYPEID = "TRANSACTIONCODE_TRANSACTIONCODETYPEID";
            public const string TRANSACTIONCATALOGID = "TRANSACTIONCATALOGID";

            public const string Purpose = "PURPOSE";

            public const string LANGUAGE = "LANGUAGE";

            public const string CF_MANTY = "CF_MANTY";
            public const string CF_GROUPOPENACCNO = "CF_GROUPOPENACCNO";
            public const string CF_MERGETRADE = "CF_MERGETRADE";
            public const string CF_IDTYPE = "CF_IDTYPE";
            public const string CF_REFERTYPE = "CF_REFERTYPE";
            public const string CF_CLEARING = "CF_CLEARING";
            public const string CF_TRANSACTIONTYPE = "CF_TRANSACTIONTYPE";
            public const string CF_CLOSEREASON = "CF_CLOSEREASON";
            public const string CF_ACCOUNTSTATUS = "CF_ACCOUNTSTATUS";
            public const string CF_VSDSTATUS = "CF_VSDSTATUS";
            public const string CF_GATEWAYRECORDSTATUS = "CF_GATEWAYRECORDSTATUS";
            public const string CF_CUSTODIANACCOUNTTYPE = "CF_CUSTODIANACCOUNTTYPE";
            public const string CF_DESTATUS = "CF_DESTATUS";
            public const string CF_TESTATUS = "CF_TESTATUS";
            public const string CF_TYPE = "CF_TYPE";
            public const string CF_EXPIREDSTS = "CF_EXPIREDSTS";
            public const string CF_AUTHORITYSCOPE = "CF_AUTHORITYSCOPE";
            public const string CF_AUTHTYPE = "CF_AUTHTYPE";
            public const string CF_REGISTRATIONTYPE = "CF_REGISTRATIONTYPE";
            public const string CF_BROKERCARE = "CF_BROKERCARE";
            public const string CF_RESIDENTTYPE = "CF_RESIDENTTYPE";
            public const string CF_AUTHENTYPE = "CF_AUTHENTYPE";
            public const string CF_OPNVIA = "CF_OPNVIA";
            public const string CF_VSDSTS = "CF_VSDSTS";
            public const string CF_DOCUMENTSTS = "CF_DOCUMENTSTS";
            public const string CF_PROINVESTUN = "CF_PROINVESTUN";
            public const string CF_PROINVESTDE = "CF_PROINVESTDE";
            public const string CF_CFREPRESENTER = "CF_CFREPRESENTER";
            public const string LEGALPRESENTTYPE = "LEGALPRESENTTYPE";
            public const string CF_OPERATORACCOUNT = "CF_OPERATORACCOUNT";
            public const string CF_PROFESSIONALINVESTORSTYPE = "CF_PROFESSIONALINVESTORSTYPE";
            public const string CF_OPENVIA = "CF_OPENVIA";
            public const string ACCOUNT_CLOSING_FEE = "ACCOUNT_CLOSING_FEE";

            public const string CFMAST_STATUS = "CFMAST_STATUS";
            public const string CF_STATUS = "CF_STATUS";

            public const string CFAUTH_CONTROLTYPE = "CFAUTH_CONTROLTYPE";

            public const string CFADDRESS_ADDTYPE = "CFADDRESS_ADDTYPE";
            public const string CFADDRESS_INFOTYPE = "CFADDRESS_INFOTYPE";

            public const string CFBANKACCOUNT_ISMASTER = "CFBANKACCOUNT_ISMASTER";
            public const string CFBANKACCOUNT_CASHINTERFACETYPE = "CFBANKACCOUNT_CASHINTERFACETYPE";
            public const string CFBANKACCOUNT_STATUS = "CFBANKACCOUNT_STATUS";

            public const string CFDOCUMENT_CFGROUPSIGN = "CFDOCUMENT_CFGROUPSIGN";
            public const string CFDOCUMENT_DATATYPE = "CFDOCUMENT_DATATYPE";

            public const string CFNOTIFICATION_DATATYPE = "CFNOTIFICATION_DATATYPE";

            public const string CFREGTRANFERMONEY_TRANTYPE = "CFREGTRANFERMONEY_TRANTYPE";

            public const string CONTACT_ADDTYPE = "CONTACT_ADDTYPE";
            public const string CONTACT_INFOTYPE = "CONTACT_INFOTYPE";

            public const string AFINVESTMENTTRUST_STATUS = "AFINVESTMENTTRUST_STATUS";

            public const string DecimalPlaces = "DECIMALPLACES";
            public const string Title = "TITLE";
            public const string ContactType = "CONTACTTYPE";
            public const string FeeRounding = "FEE_ROUNDING";
            public const string Criteria = "CRITERIA";
            public const string DISCOUNTTYPE_EQT = "DISCOUNTTYPE_EQT";
            public const string DISCOUNTTYPE_FOS = "DISCOUNTTYPE_FOS";
            public const string PROMOTION_METHOD = "PROMOTION_METHOD";
            public const string CF_NOTIGROUP = "CF_NOTIGROUP";

            public const string REPORTCATEGORYID = "REPORTCATEGORYID";
            public const string CASH_EQUITY_WORKFLOWSTATUS = "CASH_EQUITY_WORKFLOWSTATUS";

            public const string FUNCTION_FUNCTIONTYPE = "FUNCTION_FUNCTIONTYPE";

            public const string FEE_INTERESTCLASS_RATETYPE = "FEE_INTERESTCLASS_RATETYPE";
            public const string FEE_CALCULATEBY_EQT = "FEE_CALCULATEBY_EQT";
            public const string FEE_CALCULATEBY_FOS = "FEE_CALCULATEBY_FOS";
            public const string RATEDIVISOR = "RATEDIVISOR";

            public const string FEE_FEENATURETYPE_FOS = "FEE_FEENATURETYPE_FOS";
            public const string FEE_FEENATURETYPE_EQT = "FEE_FEENATURETYPE_EQT";
            public const string FEE_FEENATURECATEGORY_FOS = "FEE_FEENATURECATEGORY_FOS";
            public const string FEE_FEENATURECATEGORY_EQT = "FEE_FEENATURECATEGORY_EQT";
            public const string FEE_OPERANDTYPE_OPERANDTYPE = "FEE_OPERANDTYPE_OPERANDTYPE";
            public const string FEE_PERIODTYPE = "FEE_PERIODTYPE";
            public const string DIVISORTYPE = "DIVISORTYPE";

            public const string CASHWITHDRAW_TRANSFERTYPE = "CASHWITHDRAW_TRANSFERTYPE";
            public const string CASHWITHDRAW_TRANSACTIONTYPE = "CASHWITHDRAW_TRANSACTIONTYPE";
            public const string CASHHOLDTYPE = "CASHHOLDTYPE";
        }


        public static class Side
        {
            public const string Buy = "B";
            public const string Sell = "S";

            public static bool IsBuy(string side)
            {
                return string.Equals(side, Side.Buy);
            }

            public static bool IsSell(string side)
            {
                return string.Equals(side, Side.Sell);
            }
        }


        public static class StringCharacters
        {
            public const string One = "1";
            public const string Space = " ";
            public const string Comma = ",";
            public const string Dot = ".";
            public const string Pipe = "|";
            public const string Hyphen = "-";
        }
    }
}