using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Customer
    {
        [Key]
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
        [StringLength(50)]
        [Required(ErrorMessage = "Phone Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone#")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(320)]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public long CreatedByID { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public long ModifiedByID { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Country Required")]
        public Int32 CountryID { get; set; }
        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "Province Required")]
        public Int32 ProvinceID { get; set; }
        public virtual Province Province { get; set; }
    }
}