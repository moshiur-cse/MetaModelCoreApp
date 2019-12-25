using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectLocations
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string DivCode { get; set; }
        public string DistCode { get; set; }
        public string UpzCode { get; set; }

        public virtual GeoUpazilas UpzCodeNavigation { get; set; }
    }
}
