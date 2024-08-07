using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Endpoint.Models.ViewModels.Register
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        [DisplayName("نام و نام خانوادگی")]
        [MaxLength(50, ErrorMessage ="نام و نام خانوادگی نباید بیشتر از 50 کاراکتر باشد")]
        public string FullName { get; set; }



        [Required(ErrorMessage ="آدرس ایمیل را وارد کنید")]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage ="کلمه عبور را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name ="کلمه عبور")]
        public string Password { get; set; }


        [Required(ErrorMessage ="تکرار کلمه عبور را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور و تکرار آن باید برابر باشند")]
        [Display(Name ="تکرار کلمه عبور")]
        public string RePassword { get; set; }

        public string PhoneNumber {  get; set; }
    }
}
