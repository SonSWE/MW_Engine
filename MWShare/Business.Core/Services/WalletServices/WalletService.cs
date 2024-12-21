using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using FluentValidation;
using Object.Core;
using System.Data;
using CommonLib.Constants;
using Business.Core.Services.BaseServices;
using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.FreelancerBLs;
using System;
using Object;
using Business.Core.BLs.WalletBLs;
using CommonLib.Extensions;

namespace Business.Core.Services.WalletServices
{
    public class WalletService : MasterDataBaseService<MWWallet>, IWalletService
    {
        private readonly IMasterDataBaseBL<MWTransaction> _transactionBL;
        private readonly IWalletBL _walletBL;
        public WalletService(IMasterDataBaseBL<MWWallet> masterDataBaseDA, IDbManagement dbManagement,
            IMasterDataBaseBL<MWTransaction> transactionBL, IWalletBL walletBL) : base(masterDataBaseDA, dbManagement)
        {
            _transactionBL = transactionBL;
            _walletBL = walletBL;
        }
        public override string ProfileKeyField => Const.ProfileKeyField.Wallet;
        public override BaseValidator<MWWallet> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, MWWallet dataToValidate, MWWallet oldData)
        {
            return new WalletValidator(validationAction, clientInfo?.ClientLanguage ?? string.Empty)
            {
                ClassLevelCascadeMode = CascadeMode.Stop,
                RuleLevelCascadeMode = CascadeMode.Stop,
            };
        }
        public long Deposit(MWTransaction data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Err_Unknown;

            //lấy thông tin ví hiện tại
            MWWallet oldData = MasterDataBaseBL.GetDetailById(transaction, data.WalletId);
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }
            //kiểm tra trạng thái ví gửi
            if (string.Equals(oldData.Status, Const.Wallet_Status.Inactive))
            {
                resMessage = "Ví của bạn chưa được phép giao dịch";
                return ErrorCodes.CUS_Wallet.Err_StatusInactive;
            }

            //
            MWWallet updateData = oldData.Clone();

            //Cộng tiền vào ví
            updateData.Balance = oldData.Balance + data.Amount;
            updateData.LastChangeBy = clientInfo.UserName;
            updateData.LastChangeDate = DateTime.Now;

            //tạo lịch sử giao dịch
            MWTransaction transactionDeposit = data.Clone();
            transactionDeposit.Status = Const.Transaction_Status.Succeed;
            transactionDeposit.TransactionType = Const.Transaction_Type.Deposit;
            transactionDeposit.TransactionDate = DateTime.Now;

            //thêm mới lịch sử giao dịch
            result = _transactionBL.Insert(transaction, transactionDeposit, clientInfo);
            if (result > 0)
            {
                //lưu thông tin tiền vào ví
                result = MasterDataBaseBL.UpdateData(transaction, updateData, oldData, clientInfo);
            }


            if (result > 0)
            {
                resMessage = "Nạp tiền thành công";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public long Withdraw(MWTransaction data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Err_Unknown;

            //lấy thông tin ví hiện tại
            MWWallet oldData = MasterDataBaseBL.GetDetailById(transaction, data.WalletId);
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }
            //kiểm tra trạng thái ví gửi
            if (string.Equals(oldData.Status, Const.Wallet_Status.Inactive))
            {
                resMessage = "Ví của bạn chưa được phép giao dịch";
                return ErrorCodes.CUS_Wallet.Err_StatusInactive;
            }

            //
            MWWallet updateData = oldData.Clone();

            //Trừ tiền trong ví
            updateData.Balance = oldData.Balance - data.Amount;
            updateData.LastChangeBy = clientInfo.UserName;
            updateData.LastChangeDate = DateTime.Now;

            //tạo lịch sử giao dịch
            MWTransaction transactionWithdraw = data.Clone();
            transactionWithdraw.Status = Const.Transaction_Status.Succeed;
            transactionWithdraw.TransactionType = Const.Transaction_Type.Withdraw;
            transactionWithdraw.TransactionDate = DateTime.Now;

            //Thực hiện chuyền tiền từ hệ thống đến tài khoản ngân hàng

            //thêm mới lịch sử giao dịch
            result = _transactionBL.Insert(transaction, transactionWithdraw, clientInfo);
            if (result > 0)
            {
                //lưu thông tin tiền vào ví
                result = MasterDataBaseBL.UpdateData(transaction, updateData, oldData, clientInfo);
            }


            if (result > 0)
            {
                resMessage = "Rút tiền thành công";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }


        public long Transfer(MWTransaction data, ClientInfo clientInfo, out string resMessage)
        {
            resMessage = string.Empty;

            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            long result = ErrorCodes.Err_Unknown;

            //lấy thông tin ví người gửi
            MWWallet oldTransfer = MasterDataBaseBL.GetDetailById(transaction, data.WalletId);
            if (oldTransfer == null || string.IsNullOrEmpty(oldTransfer.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }
            //kiểm tra trạng thái ví gửi
            if (string.Equals(oldTransfer.Status, Const.Wallet_Status.Inactive))
            {
                resMessage = "Ví của bạn chưa được phép giao dịch";
                return ErrorCodes.CUS_Wallet.Err_StatusInactive;
            }
            //
            //Trừ tiền trong ví người gửi
            MWWallet updateTransfer = oldTransfer.Clone();
            updateTransfer.Balance = updateTransfer.Balance - data.Amount;
            updateTransfer.LastChangeBy = clientInfo.UserName;
            updateTransfer.LastChangeDate = DateTime.Now;
            //tạo lịch sử giao dịch chuyển tiền
            MWTransaction transactionTransfer = data.Clone();
            transactionTransfer.Status = Const.Transaction_Status.Succeed;
            transactionTransfer.TransactionType = Const.Transaction_Type.Transfer;
            transactionTransfer.TransactionDate = DateTime.Now;
            transactionTransfer.WalletReceiveId = data.WalletReceiveId;
            transactionTransfer.WalletTransferId = data.WalletId;
            transactionTransfer.WalletId = data.WalletId;

            //lấy thông tin ví người nhận
            MWWallet oldReceiver = MasterDataBaseBL.GetDetailById(transaction, data.WalletReceiveId);
            if (oldReceiver == null || string.IsNullOrEmpty(oldReceiver.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }
            //
            //
            //Cộng tiền ví người nhận
            MWWallet updateReciver = oldReceiver.Clone();
            updateReciver.Balance = updateReciver.Balance + data.Amount;
            updateReciver.LastChangeBy = clientInfo.UserName;
            updateReciver.LastChangeDate = DateTime.Now;
            //tạo lịch sử giao dịch nhận tiền
            MWTransaction transactionReceive = new MWTransaction();
            transactionReceive.Amount = data.Amount;
            transactionReceive.Status = Const.Transaction_Status.Succeed;
            transactionReceive.TransactionType = Const.Transaction_Type.Receive;
            transactionReceive.TransactionDate = DateTime.Now;
            transactionReceive.WalletReceiveId = data.WalletReceiveId;
            transactionReceive.WalletTransferId = data.WalletId;
            transactionReceive.WalletId = data.WalletReceiveId;


            //Thực hiện chuyền tiền từ hệ thống đến tài khoản ngân hàng

            //xử lý tiền của người nhận
            result = _transactionBL.Insert(transaction, transactionReceive, clientInfo);
            if (result > 0)
            {
                //lưu thông tin tiền vào ví
                result = MasterDataBaseBL.UpdateData(transaction, updateReciver, oldReceiver, clientInfo);
            }

            //xử lý tiền của người gửi
            if (result > 0)
            {

                result = _transactionBL.Insert(transaction, transactionTransfer, clientInfo);
                if (result > 0)
                {
                    //lưu thông tin tiền vào ví
                    result = MasterDataBaseBL.UpdateData(transaction, updateTransfer, oldTransfer, clientInfo);
                }
            }


            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public MWWallet GetDetailByUserName(string userName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();
            return _walletBL.GetDetailByUserName(transaction, userName);
        }
    }
}
