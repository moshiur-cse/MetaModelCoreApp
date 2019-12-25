using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class VwCropLoss
    {
        public int? Id { get; set; }
        public DateTime? CollectedDate { get; set; }
        public string UpzCode { get; set; }
        public int? CropTypeId { get; set; }
        public double? AreaAffectedHa { get; set; }
        public int? LossTypeId { get; set; }
        public double? LossMt { get; set; }
    }
}
