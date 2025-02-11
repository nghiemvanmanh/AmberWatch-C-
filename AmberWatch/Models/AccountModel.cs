using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmberWatch.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
    }
}