using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTap5_61131562.Models
{
    public class EmpModel
    {
        [DisplayName("Mã số nhân viên:")]
        public string EmpID { get; set; }
        [DisplayName("Họ và tên:")]
        public string Name { get; set; }
        [DisplayName("Ngày sinh:")]
        [DataType(DataType.Date)]
        public DateTime BirthOfDate { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Mật khẩu:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Đơn vị:")]
        public string Department { get; set; }
    }
}