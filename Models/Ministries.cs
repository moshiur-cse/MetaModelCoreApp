using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Ministries
    {
        public Ministries()
        {
            MinistryProjects = new HashSet<MinistryProjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<MinistryProjects> MinistryProjects { get; set; }
    }
}
