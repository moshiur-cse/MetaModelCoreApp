using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class VwCropLoseAnnual
    {
        public string UpzCode { get; set; }
        public double? CollectedDate { get; set; }
        public int? RunCode { get; set; }
        public int? CropTypeId { get; set; }
        public double? AreaAffectedHa { get; set; }
        public double? LossMtAnnual { get; set; }
        public int? LossTypeId { get; set; }
    }
}
