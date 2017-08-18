using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CustomerID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth Date Required")]
        [Display(Name = "Birth Date")]
        public Nullable<DateTime> BirthDate { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(320)]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
    }
}