using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectWithBdpGoals
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string BdpGoalsCode { get; set; }

        public virtual BdpGoals BdpGoalsCodeNavigation { get; set; }
        public virtual Projects ProjectCodeNavigation { get; set; }
    }
}
