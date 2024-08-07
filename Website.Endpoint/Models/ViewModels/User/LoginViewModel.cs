using System.ComponentModel.DataAnnotations;

namespace Website.Endpoint.Models.ViewModels.User
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="لطفاً ایمیل خود را وارد نمایید")]
        [Display(Name ="ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage ="لطفاً کلمه عبور را وارد نمایید")]
        [Display(Name ="کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name ="Remember Me")]
        public bool IsPersistence {  get; set; } = false;

        public string ReturnUrl { get; set; }


    }
}
