using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KintaiKanri.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子メール")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "コード")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "認証情報をこのブラウザーに保存しますか?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "メールアドレス")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        [Display(Name = "このアカウントを記憶する")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員番号")]
        public string No { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員名")]
        public string SyainName { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [StringLength(100, ErrorMessage = "{0} の長さは {2} 文字以上である必要があります。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "パスワードの確認入力")]
        [Compare("Password", ErrorMessage = "パスワードと確認のパスワードが一致しません。")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} の長さは {2} 文字以上である必要があります。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "パスワードの確認入力")]
        [Compare("Password", ErrorMessage = "パスワードと確認のパスワードが一致しません。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
    }
}
