using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmberWatch.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}