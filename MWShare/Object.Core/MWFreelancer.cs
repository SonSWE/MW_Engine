using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWFreelancer, ViewName = $"VW_{Const.DbTable.MWFreelancer}")]
    public sealed class MWFreelancer : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string FreelancerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; } //vị trí
        public DateTime DateOfBirth { get; set; } //ngày sinh
        public string LevelId { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string LevelIdText { get; set; }
        public string Title { get; set; } // tiêu đầu công việc
        public string Bio { get; set; } // mô tả bản thân
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        public string IsOpeningForJob { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsOpeningForJobText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string SkillsText { get; set; }
        public decimal HourlyRate { get; set; } // số tiền công mỗi giờ
        public decimal HourWorkingPerWeek { get; set; } // Số giờ làm việc trên một tuần



        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWFreelancerSpecialty> Specialties { get; set; }  //chuyên ngành

        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWFreelancerSkill> Skills { get; set; } //kỹ năng
        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWFreelancerEducation> Educations { get; set; } //học vấn

        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWFreelancerWorkingHistory> WorkingHistories { get; set; } //lịch sử làm việc
        [DbField(IgnoreInsert = true, IgnoreUpdate = true, IsDetailTable = true)]
        public List<MWFreelancerCertificate> Certificates { get; set; } //chứng chỉ

        //thong tin cho user
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Password { get; set; } //mật khẩu
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Avatar { get; set; } //id file ảnh đại diện
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IdentityCard { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IdentityAddress { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public DateTime IdentityIssueDate { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public DateTime IdentityExpirationDate { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsEkycVerified { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsEmailVerified { get; set; } = Const.YN.No;
    }
}
