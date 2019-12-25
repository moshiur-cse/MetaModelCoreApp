using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class GeoUpazilas
    {
        public GeoUpazilas()
        {
            CropLoss = new HashSet<CropLoss>();
            CropLosses = new HashSet<CropLosses>();
            ProjectLocations = new HashSet<ProjectLocations>();
        }

        public int SlNo { get; set; }
        public string DivCode { get; set; }
        public string DistCode { get; set; }
        public string UpzCode { get; set; }
        public string UpzName { get; set; }

        public virtual GeoDistricts DistCodeNavigation { get; set; }
        public virtual ICollection<CropLoss> CropLoss { get; set; }
        public virtual ICollection<CropLosses> CropLosses { get; set; }
        public virtual ICollection<ProjectLocations> ProjectLocations { get; set; }
    }
}
