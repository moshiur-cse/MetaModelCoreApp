using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectWithStrategies
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string StrategiesCode { get; set; }

        public virtual Projects ProjectCodeNavigation { get; set; }
        public virtual Strategies StrategiesCodeNavigation { get; set; }
    }
}
