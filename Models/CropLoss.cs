using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class CropLoss
    {
        public int Id { get; set; }
        public DateTime CollectedDate { get; set; }
        public string UpzCode { get; set; }
        public int CropTypeId { get; set; }
        public int LossTypeId { get; set; }
        public string IndicatorCode { get; set; }
        public double IndicatorValue { get; set; }
        public int RunCode { get; set; }

        public virtual CropTypes CropType { get; set; }
        public virtual LossTypes LossType { get; set; }
        public virtual SenarioStrategies RunCodeNavigation { get; set; }
        public virtual GeoUpazilas UpzCodeNavigation { get; set; }
    }
}
