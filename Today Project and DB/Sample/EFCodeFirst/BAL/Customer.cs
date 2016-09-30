using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.BAL
{
    public class Customer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [StringLength(50)]
        [Required]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(320)]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
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
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public Int32 CountryID { get; set; }
        public virtual Country Country { get; set; }

        public Int32 ProvinceID { get; set; }
        public virtual Province Province { get; set; }
    }
}