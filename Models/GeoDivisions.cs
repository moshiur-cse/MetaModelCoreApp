using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class GeoDivisions
    {
        public GeoDivisions()
        {
            GeoDistricts = new HashSet<GeoDistricts>();
        }

        public int SlNo { get; set; }
        public string DivCode { get; set; }
        public string DivName { get; set; }

        public virtual ICollection<GeoDistricts> GeoDistricts { get; set; }
    }
}
