using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class CropLosses
    {
        public int Id { get; set; }
        public DateTime CollectedDate { get; set; }
        public string UpzCode { get; set; }
        public int CropTypeId { get; set; }
        public double AreaAffectedHa { get; set; }
        public int LossTypeId { get; set; }
        public double LossMt { get; set; }
        public int RunCode { get; set; }

        public virtual CropTypes CropType { get; set; }
        public virtual LossTypes LossType { get; set; }
        public virtual SenarioStrategies RunCodeNavigation { get; set; }
        public virtual GeoUpazilas UpzCodeNavigation { get; set; }
    }
}
