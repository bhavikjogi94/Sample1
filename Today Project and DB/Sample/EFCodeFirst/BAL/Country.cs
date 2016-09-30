using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.BAL
{
    public class Country
    {
        [Key]
        ////[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 CountryID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
        public string CountryName { get; set; }
    }
}