using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Globalization;

namespace SDFAuth2.Models
{

    public class LoginModel
    {
        [DisplayName("用户名")]
        [Remote("Exists", "Account", ErrorMessage = "用户账号已存在")]
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        [Required]
        public string Password { get; set; }

        [DisplayName("验证码")]
        public string ValidateCode { get; set; }

        [DisplayName("记住我?")]
        public bool RememberMe { get; set; }
    }
}
