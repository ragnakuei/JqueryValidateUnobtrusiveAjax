using System;
using System.ComponentModel.DataAnnotations;

namespace JqueryValidateUnobtrusiveAjax.Models
{
    public class TestDto
    {
        [Display(Name                                 = "名稱", Prompt = "名稱")]
        [Required(ErrorMessage                        = "請填寫{0}")]
        [StringLength(maximumLength: 5, MinimumLength = 2, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
        public string Name { get; set; }

        [Display(Name                                = "單價", Prompt = "單價")]
        [Required(ErrorMessage                       = "請填寫{0}")]
        [Range(minimum: 1, maximum: 10, ErrorMessage = "{0} 要介於 {2} 及 {1} 之間")]
        [RegularExpression("([0-9]+)", ErrorMessage  = "請輸入正整數")]
        public int? UnitPrice { get; set; }

        [Display(Name          = "分配日期", Prompt = "分配日期")]
        [Required(ErrorMessage = "請填寫{0}")]
        [DataType(DataType.Date)]
        public DateTime? AssignDate { get; set; }
    }
}