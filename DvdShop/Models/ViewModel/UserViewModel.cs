using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Hãy nhập tên đăng nhập")]
        [MaxLength(20)]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
    }
}