using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class BdpWithIndicator
    {
        public int Id { get; set; }
        public string IndicatorCode { get; set; }
        public string BdpGoalsCode { get; set; }

        public virtual BdpGoals BdpGoalsCodeNavigation { get; set; }
        public virtual Indicator IndicatorCodeNavigation { get; set; }
    }
}
