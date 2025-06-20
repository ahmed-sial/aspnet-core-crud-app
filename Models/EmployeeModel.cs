using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeWebApplication.Models
{
    public class EmployeeModel
    {
        [Key]
        [Column("id")]
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Column("f_name", TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be between 3 to 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Column("l_name", TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be between 3 to 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Column("age", TypeName = "INT")]
        [Required(ErrorMessage = "This field is required")]
        [Range(18, 60, ErrorMessage = "The range should be between 18 to 60.")]
        [Display(Name = "Age")]
        public int? Age { get; set; }

    }
}
