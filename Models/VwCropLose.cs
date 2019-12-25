using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class VwCropLose
    {
        public double? CollectedDate { get; set; }
        public string UpzCode { get; set; }
        public double? AreaAffectedHa { get; set; }
        public double? LossMt { get; set; }
        public int? RunCode { get; set; }
    }
}
