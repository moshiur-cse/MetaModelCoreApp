using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class MinistryProjects
    {
        public int Id { get; set; }
        public int MinistryId { get; set; }
        public string ProjectCode { get; set; }

        public virtual Ministries Ministry { get; set; }
        public virtual Projects ProjectCodeNavigation { get; set; }
    }
}
