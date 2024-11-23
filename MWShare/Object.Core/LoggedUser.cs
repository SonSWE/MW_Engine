using System.Collections.Generic;
using System.Linq;
using CommonLib.Constants;

namespace Object.Core
{
    public sealed class LoggedUser
    {
        public string UserName { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string NameOther { get; set; }
        public string RptFuncCanViewAllBranches { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }
        public string ReadOnlyUser { get; set; }
        public bool MustChangePassword { get; set; }
        //
        public List<LoggedUserRole> UserRoles { get; set; }
        public List<LoggedUserFunction> FunctionSettings { get; set; }
        public List<LoggedUserUserInputApprovalLimit> InputSettings { get; set; }
        public List<LoggedUserUserInputApprovalLimit> ApprovalSettings { get; set; }
        public List<LoggedUserAccessibleBranch> AccessibleBranches { get; set; }
        //
        public bool IsAllowCheckAccessHierachy(string functionId)
        {
            return string.Equals(FunctionSettings?.FirstOrDefault(x => string.Equals(x.FunctionId, functionId))?.AllowCheckAccessHierachy, Const.YN.Yes);
        }

        public bool CanAccessBranchId(string branchId)
        {
            return string.Equals(BranchId, branchId)
                || AccessibleBranches?.Any(x => string.Equals(x.BranchId, branchId)) == true;
        }

        public bool CanAccessBranchAndDepartmentId(string branchId, string departmentId)
        {
            //Check trong userAccessibleBranches có bản ghi có branchType = D và branchId và departmentId không
            if (AccessibleBranches?.Any(x => x.BranchType == Const.BranchType.Department && string.Equals(x.BranchId, branchId) && string.Equals(x.DepartmentId, departmentId)) == true)
            {
                return true;
            }
            //Không có thì check như bình thường
            else
            {
                return AccessibleBranches?.Any(x => x.BranchType == Const.BranchType.Branch && string.Equals(x.BranchId, branchId)) == true;
            }
        }
    }

    public sealed class LoggedUserRole
    {
        public string RoleId { get; set; }
    }

    public sealed class LoggedUserFunction
    {
        public string AllowQuery { get; set; }
        public string AllowAdd { get; set; }
        public string AllowUpdate { get; set; }
        public string AllowDelete { get; set; }
        public string AllowCancel { get; set; }
        public string AllowExecute { get; set; }
        public string AllowApproveAdd { get; set; }
        public string AllowApproveUpdate { get; set; }
        public string AllowApproveDelete { get; set; }
        public string AllowApproveExecute { get; set; }
        public string AllowBackdate { get; set; }
        public string AllowNotification { get; set; }
        public string AllowImport { get; set; }
        public string AllowExport { get; set; }
        public string AllowPrint { get; set; }
        public string AllowCheckAccessHierachy { get; set; }
        //
        public string FunctionDescription { get; set; }
        public string FunctionDescriptionEn { get; set; }
        public string FunctionType { get; set; }
        public string FunctionId { get; set; }
        public string AllowCopyRecord { get; set; }
    }

    public sealed class LoggedUserUserInputApprovalLimit
    {
        public string ParameterId { get; set; }
        public string Value { get; set; }
    }

    public sealed class LoggedUserAccessibleBranch
    {
        public string BranchType { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
    }
}
