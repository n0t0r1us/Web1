using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BaiTap4_61131562.Models
{
    public class MailInfo
    {
        [DisplayName("Gửi từ email ")]
        public string From { get; set; }    
        [DisplayName("Mật khẩu ")]
        public string Password { get; set; }
        [DisplayName("Gửi đến email ")]
        public string To { get; set; }
        [DisplayName("Tiêu đề: ")]
        public string Subject { get; set; }
        [DisplayName("Nội dung: ")]
        public string Body { get; set; }
    }
}