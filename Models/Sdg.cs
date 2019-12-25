using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Sdg
    {
        public Sdg()
        {
            ProjectWithSdgGoals = new HashSet<ProjectWithSdgGoals>();
        }

        public string SdgCode { get; set; }
        public string SdgName { get; set; }
        public int? SlNo { get; set; }

        public virtual ICollection<ProjectWithSdgGoals> ProjectWithSdgGoals { get; set; }
    }
}
