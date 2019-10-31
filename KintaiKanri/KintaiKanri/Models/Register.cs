using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KintaiKanri.Models
{
    /// <summary>
    /// 社員モデル
    /// </summary>
    [Table("Syains")]
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員名")]
        public string SyainName { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員番号")]
        public string No { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [StringLength(100, ErrorMessage = "{0} の長さは {2} 文字以上である必要があります。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "パスワードの確認入力")]
        [Compare("Password", ErrorMessage = "パスワードと確認のパスワードが一致しません。")]
        public string ConfirmPassword { get; set; }

        //public int BushoId { get; set; }

        //public int RoleId { get; set; }


    }
}