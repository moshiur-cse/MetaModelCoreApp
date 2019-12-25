using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Agencies
    {
        public Agencies()
        {
            AgencyProjects = new HashSet<AgencyProjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<AgencyProjects> AgencyProjects { get; set; }
    }
}
