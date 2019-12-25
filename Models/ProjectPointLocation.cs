using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectPointLocation
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Remarks { get; set; }

        public virtual Projects ProjectCodeNavigation { get; set; }
    }
}
