using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Indicator
    {
        public Indicator()
        {
            BdpWithIndicator = new HashSet<BdpWithIndicator>();
        }

        public string IndicatorCode { get; set; }
        public string IndicatorName { get; set; }
        public string IndicatorIdBdp { get; set; }
        public string IndicatorDescription { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<BdpWithIndicator> BdpWithIndicator { get; set; }
    }
}
