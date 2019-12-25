using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class AgencyProjects
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string ProjectCode { get; set; }

        public virtual Agencies Agency { get; set; }
        public virtual Projects ProjectCodeNavigation { get; set; }
    }
}
