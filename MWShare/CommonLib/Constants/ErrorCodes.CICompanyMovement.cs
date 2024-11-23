namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {
        // Ma loi phan he CI (Cash Information): -11_XX_YYY;
        // XX: 2 so the hien bang
        //		+ 00: CIMAST                        - TABLE     - Tài khoản tiền
        //		+ 01: CIDEPOSITORY                  - TABLE     - Giao dịch nộp tiền
        //		+ 02: CashDepository                - BUSINESS  - Nộp tiền
        //		+ 03: DepositIM                     - BUSINESS  - Nộp tiền Phái sinh
        //		+ 04: WithdrawIM                     - BUSINESS  - Rút tiền Phái sinh
        //		+ 05: PaymentST                     - BUSINESS  - Công ty nộp ST lỗ NET cho VSD
        //		+ 11: CashWithdraw                     - BUSINESS  - Rut tien
        //		+ 80: TACompanyMovement (TA: Transtion Assest): Lưu thông tin các giao dịch mức công ty
        // YYY: 3 so the hien loi
        public static class CompanyMovementErrorCode
        {
            public const int Err_MovementID = -11_80_001;  // [MovementID] không hợp lệ | [MovementID] invalid
            public const int Err_TransactionType = -11_80_002;  // [TransactionType] không hợp lệ | [TransactionType] invalid
            public const int Err_CurrencyID = -11_80_003;  // [CurrencyID] không hợp lệ | [CurrencyID] invalid
            public const int Err_MovementCodeID = -11_80_004;  // [MovementCodeID] không hợp lệ | [MovementCodeID] invalid
            public const int Err_MovementTypeID = -11_80_005;  // [MovementTypeID] không hợp lệ | [MovementTypeID] invalid
            public const int Err_SettlementAmount = -11_80_006;  // [SettlementAmount] không hợp lệ | [SettlementAmount] invalid
            public const int Err_Amount = -11_80_007;  // [Amount] không hợp lệ | [Amount] invalid
            public const int Err_BankAccountID = -11_80_008;  // [BankAccountID] không hợp lệ | [BankAccountID] invalid
            public const int Err_ValueDate = -11_80_009;  // [ValueDate] không hợp lệ | [ValueDate] invalid
            public const int Err_Remarks = -11_80_010;  // [Remarks] không hợp lệ | [Remarks] invalid
            public const int Err_SettleStatus = -11_80_011;  // [SettleStatus] không hợp lệ | [SettleStatus] invalid
            public const int Err_ExternalState = -11_80_012;  // [ExternalState] không hợp lệ | [ExternalState] invalid
            public const int Err_ExternalStateDescription = -11_80_013;  // [ExternalStateDescription] không hợp lệ | [ExternalStateDescription] invalid
            public const int Err_LimitInput = -11_80_014;  // Vượt quá hạn mức có thể nhập. Hạn mức: {0} | Input over limit: Limit {0}
            public const int Err_LimitApprove = -11_80_015;  // Vượt quá hạn mức có thể duyệt. Hạn mức: {0} | Input over approval limit: Limit {0}
        }

        public static class PostCollateralFeeErrorCode
        {
            public const int Err_AccountAccuredFeeTransaction = -11_81_001;  // [AccountAccuredFeeTransaction] Lỗi xử lý dữ liệu | [AccountAccuredFeeTransaction] error process data
            public const int Err_AccountAccuredFee = -11_81_002;  // [AccountAccuredFee] Lỗi xử lý dữ liệu | [AccountAccuredFee] error process data
            public const int Err_AccountCashDer = -11_81_003;  // [AccountCashDer] Lỗi xử lý dữ liệu | [AccountCashDer] error process data
            public const int Err_SAccountTransaction = -11_81_004;  // [SAccountTransaction] Lỗi xử lý dữ liệu | [SAccountTransaction] error process data
            public const int Err_SAccountTransactionDetail = -11_81_005;  // [SAccountTransactionDetail] Lỗi xử lý dữ liệu | [SAccountTransactionDetail] error process data
            public const int Err_DataNull = -11_81_006;  // Không có bản ghi để thực hiện | No data exist
            public const int Err_Insert_Mttran = -11_81_007;  // Lỗi insert mttran | Error insert Mttran
        }


        public static class InterestAdjustmentErrorCode
        {
            public const int Err_MCCustomer_Invalid = -11_82_001; // Khách hàng không tồn tại | Customer not exist
            public const int Err_MCAccount_Invalid = -11_82_002; // Tài khoản không hợp lệ | Account invalid
            public const int Err_TPAccountAccruedInterest_PostStatus_Invalid = -11_82_003; // [PostStatus] Dữ liệu gửi vào không hợp lệ | [PostStatus] data invalid
            public const int Err_TPAccountAccruedInterest_Insert_Invalid = -11_82_004; // Lỗi save dữ liệu vào TPAccountAccruedInterest | Error save to TPAccountAccruedInterest
            public const int Err_TPAccountAccruedInterest_Update_Invalid = -11_82_005; // Lỗi cập nhật dữ liệu vào TPAccountAccruedInterest | Error update to TPAccountAccruedInterest 
            public const int Err_TPAccountAccruedInterest_Delete_Invalid = -11_82_006; // Lỗi xóa dữ liệu vào TPAccountAccruedInterest | Error delete data TPAccountAccruedInterest 
            public const int Err_MTTran_Insert_Invalid = -11_82_007; // Lỗi ghi dữ liệu vào MTTran | Error save to MTTran 
            public const int Err_TPAccountAccruedInterestTransaction_Insert_Invalid = -11_82_008; // Lỗi ghi dữ liệu vào TPAccountAccruedInterestTransaction | Error save to TPAccountAccruedInterestTransaction
            public const int Err_TPAccountAccruedInterest_NotExist = -11_82_009; // Không tồn tại bản ghi trong AccountAccruedInterest | Not exist record AccountAccruedInterest
            public const int Err_BCAccountCashDer_Update_Invalid = -11_82_010; // Lỗi cập nhật dữ liệu BCAccountCashDer | Error update to BCAccountCashDer 
            public const int Err_TPAccountAccruedInterest_RecordStatus_Invalid = -11_82_011; // RecordStatus AccountAccruedInterest không hợp lệ | AccountAccruedInterest RecordStatus invalid
            public const int Err_TPAccountAccruedInterest_Approve_Invalid = -11_82_012; // Dữ liệu duyệt gửi vào không để trống || Data aprrove not null
            public const int Err_TPAccountAccruedInterestTransaction_Update_Invalid = -11_82_013; // Lỗi cập nhật dữ liệu vào TPAccountAccruedInterestTransaction | Error update to TPAccountAccruedInterestTransaction 
            public const int Err_SAccountTransaction = -11_82_014;  // [SAccountTransaction] Lỗi xử lý dữ liệu | [SAccountTransaction] error process data
            public const int Err_SAccountTransactionDetail = -11_82_015;  // [SAccountTransactionDetail] Lỗi xử lý dữ liệu | [SAccountTransactionDetail] error process data
            public const int Err_Save_Override_Exist = -11_82_016;  // Đang tồn tại giao dịch điều chỉnh chờ duyệt, không thể tạo giao dịch điều chỉnh mới | There is an existing adjustment transaction waiting for approval, a new adjustment transaction cannot be created
            public const int Err_TPAccountAccruedInterest_PostingDate_Invalid = -11_82_017; // [PostingDate] Dữ liệu gửi vào không hợp lệ | [PostingDate] data invalid
            public const int Err_TPAccountAccruedInterest_PostingId_Invalid = -11_82_018; // Thông tin lãi đã được thanh toán không thể tạo giao dịch | Interest information has been paid and transactions cannot be created

            // từ chối
            public const int Err_Refuse_Invalid = -11_82_019; // Dữ liệu từ chối gửi vào không để trống || Data refuse not null
            public const int Err_Refuse_Not_Exist = -11_82_020; // Không tồn tại bản ghi chờ duyệt || Data not exist pending approve
            public const int Err_Refuse_RejectDes = -11_82_021; // Lý do từ chối độ dài vượt quá || Reject description invalid lenght

            // Không được phép hủy
            public const int Err_Cancel_RequestNull = -11_82_022; // Dữ liệu hủy gửi vào không để trống || Data cancel not null
            public const int Err_TPAccountAccruedInterestTransaction_Delete_Invalid = -11_82_023; // [TPAccountAccruedInterestTransaction] Lỗi xử lý xóa dữ liệu | [TPAccountAccruedInterestTransaction] error process delete data
            public const int Err_Update_Invalid = -11_82_024; // [TPAccountAccruedInterestTransaction] Lỗi xử lý cập nhật dữ liệu | [TPAccountAccruedInterestTransaction] Error process update data
            public const int Err_UserApprove_Invalid = -11_82_025; // Không cho phép user nhập duyệt trùng nhau! | Do not allow users to enter and browse at the same time!
            public const int Err_RuleUpdate_Invalid = -11_82_026; // Dữ liệu cập nhật gửi vào không hợp lệ || Data update send invalid


        }
    }
}