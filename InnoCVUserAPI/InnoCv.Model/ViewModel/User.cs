using System;
using System.ComponentModel.DataAnnotations;

namespace InnoCV.Model.ViewModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(
            AllowEmptyStrings =false,
            ErrorMessageResourceType = typeof(Dictionary.ModelValidationDictionary),
            ErrorMessageResourceName = "User_NameRequired")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÓáéíóú\- ]{1,100}$",
            ErrorMessageResourceType = typeof(Dictionary.ModelValidationDictionary),
            ErrorMessageResourceName = "User_NameInvalid")]
        public string Name { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Dictionary.ModelValidationDictionary),
            ErrorMessageResourceName = "User_BirthDateRequired")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "06/06/2079", 
            ErrorMessageResourceType = typeof(Dictionary.ModelValidationDictionary), 
            ErrorMessageResourceName = "User_BirthDateInvalid")]
        public DateTime BirthDate { get; set; }

    }
}
