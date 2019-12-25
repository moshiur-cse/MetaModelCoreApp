using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class GeoDistricts
    {
        public GeoDistricts()
        {
            GeoUpazilas = new HashSet<GeoUpazilas>();
        }

        public int SlNo { get; set; }
        public string DivCode { get; set; }
        public string DistCode { get; set; }
        public string DistName { get; set; }

        public virtual GeoDivisions DivCodeNavigation { get; set; }
        public virtual ICollection<GeoUpazilas> GeoUpazilas { get; set; }
    }
}
