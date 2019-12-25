using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Strategies
    {
        public Strategies()
        {
            ProjectWithStrategies = new HashSet<ProjectWithStrategies>();
            SenarioStrategies = new HashSet<SenarioStrategies>();
        }

        public string StrategyName { get; set; }
        public int StategiesTypeCode { get; set; }
        public int StategiesTopicCode { get; set; }
        public string StategiesCode { get; set; }
        public int? SlNo { get; set; }

        public virtual StategiesTopic StategiesTopicCodeNavigation { get; set; }
        public virtual StategiesType StategiesTypeCodeNavigation { get; set; }
        public virtual ICollection<ProjectWithStrategies> ProjectWithStrategies { get; set; }
        public virtual ICollection<SenarioStrategies> SenarioStrategies { get; set; }
    }
}
