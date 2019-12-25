using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectWithSdgGoals
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string SdgGoalsCode { get; set; }

        public virtual Projects ProjectCodeNavigation { get; set; }
        public virtual Sdg SdgGoalsCodeNavigation { get; set; }
    }
}
