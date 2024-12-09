using CommonLib.Constants;
using DataAccess.Core.Interfaces;
using DataAccess.Core.SkillDAs;
using DataAccess.Core.SpencialDAs;
using DataAccess.Core.SystemCodeDAs;
using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Core.Services.SystemServices
{
    public sealed class CommonService : ICommonService
    {
        private readonly ICommonDA _commonDA;
        private readonly ISystemCodeDA _systemCodeDA;
        private readonly ISystemCodeValueDA _systemCodeValueDA;

        private readonly ISkillDA _skillDA;
        private readonly ISpecialtyDA _specialtyDA;

        public CommonService(ICommonDA commonML, ISystemCodeDA systemCodeDA, ISystemCodeValueDA systemCodeValueDA, ISkillDA skillDA, ISpecialtyDA specialtyDA)
        {
            _commonDA = commonML;
            _systemCodeDA = systemCodeDA;
            _systemCodeValueDA = systemCodeValueDA;
            _skillDA = skillDA;
            _specialtyDA = specialtyDA;
        }

        //
        public string GetBusDate()
        {
            return _commonDA.GetBusDate();
        }

        public bool IsWorkingDate(DateTime date)
        {
            return _commonDA.IsWorkingDate(date);
        }

        public string GetTxNum(long branchId)
        {
            return _commonDA.GetTxNum(branchId);
        }

        public string[] GetTxNums(long branchId, int numberToGet)
        {
            return _commonDA.GetTxNums(branchId, numberToGet);
        }

        public DataSet ExecteSqlCmdToDataSet(string sqlCmd)
        {
            return _commonDA.ExecteSqlCmdToDataSet(sqlCmd);
        }


        /// <summary>
        /// Lấy danh sách SystemCode
        /// </summary>
        /// <returns></returns>
        public async Task<List<MWSystemCode>> GetSystemCodes()
        {
            var systemCodes = (await _systemCodeDA.GetAsync())?.ToList() ?? new();

            var systemCodeValues = (await _systemCodeValueDA.GetAsync())?.ToList() ?? new();

            if (systemCodes != null)
            {
                systemCodes.ForEach(sc =>
                {
                    sc.SystemCodeValues = systemCodeValues?.Where(v => string.Equals(v.SystemCodeId, sc.SystemCodeId)).ToList();
                });
            }

            return systemCodes;
        }


        public async Task<List<MWSkill>> GetSkills()
        {
            var skills = (await _skillDA.GetAsync())?.ToList() ?? new();

            return skills;
        }

        public async Task<List<MWSpecialty>> GetSpecialties()
        {
            var specialties = (await _specialtyDA.GetAsync())?.ToList() ?? new();

            return specialties;
        }
    }
}
