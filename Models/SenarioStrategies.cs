using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class SenarioStrategies
    {
        public SenarioStrategies()
        {
            CropLoss = new HashSet<CropLoss>();
            CropLosses = new HashSet<CropLosses>();
        }

        public int RunCode { get; set; }
        public int SenarioId { get; set; }
        public string StrategyCode { get; set; }

        public virtual Senarios Senario { get; set; }
        public virtual Strategies StrategyCodeNavigation { get; set; }
        public virtual ICollection<CropLoss> CropLoss { get; set; }
        public virtual ICollection<CropLosses> CropLosses { get; set; }
    }
}
