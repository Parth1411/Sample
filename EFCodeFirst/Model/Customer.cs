using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CustomerID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(320)]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
        public string Address { get; set; }
    }
}