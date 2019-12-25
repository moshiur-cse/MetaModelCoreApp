using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MetaModelCoreApp.Models
{
    public class CropType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required !")]
        [Column("id", Order = 0, TypeName = "int")]             
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required !")]
        [Column("crop_type_name", Order = 2, TypeName = "varchar(200)")]
        [StringLength(200)]
        [Display(Name = "Crop Type Name")]
        public string CropTypeName { get; set; }
    }
}
