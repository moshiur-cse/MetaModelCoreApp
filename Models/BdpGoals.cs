using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class BdpGoals
    {
        public BdpGoals()
        {
            BdpWithIndicator = new HashSet<BdpWithIndicator>();
            ProjectWithBdpGoals = new HashSet<ProjectWithBdpGoals>();
        }

        public string BdpGoalsCode { get; set; }
        public string BdpGoalsName { get; set; }
        public int? SlNo { get; set; }

        public virtual ICollection<BdpWithIndicator> BdpWithIndicator { get; set; }
        public virtual ICollection<ProjectWithBdpGoals> ProjectWithBdpGoals { get; set; }
    }
}
