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
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Password { get; set; } //mật khẩu
        public string PhoneNumber { get; set; }
        public string AvatarFileId { get; set; } //id file ảnh đại diện
        public string StreetAddress { get; set; } //vị trí
        public string CityId { get; set; } //quốc gia
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string CityIdText { get; set; } //quốc gia
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
        public decimal HourlyRate { get; set; } // số tiền công mỗi giờ
        //public decimal HourlyRateReal { get; set; } // số tiền công mỗi giờ sau phí



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
    }
}
