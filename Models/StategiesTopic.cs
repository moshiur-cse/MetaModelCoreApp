using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class StategiesTopic
    {
        public StategiesTopic()
        {
            Strategies = new HashSet<Strategies>();
        }

        public int StategiesTopicCode { get; set; }
        public string StategiesTopicName { get; set; }

        public virtual ICollection<Strategies> Strategies { get; set; }
    }
}
