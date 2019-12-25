using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class VwCropLossAnnual
    {
        public string UpzCode { get; set; }
        public double? CollectedDate { get; set; }
        public int? RunCode { get; set; }
        public int? CropTypeId { get; set; }
        public string IndicatorCode { get; set; }
        public double? IndicatorValue { get; set; }
        public int? LossTypeId { get; set; }
    }
}
