using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.BAL
{
    public class Province
    {
        [Key]
        ////[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ProvinceID { get; set; }
        [Required]
        public Int32 CountryID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
        public string ProvinceName { get; set; }
    }
}