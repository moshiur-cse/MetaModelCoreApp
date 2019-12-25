using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class CropTypes
    {
        public CropTypes()
        {
            CropLoss = new HashSet<CropLoss>();
            CropLosses = new HashSet<CropLosses>();
        }

        public int Id { get; set; }
        public string CropTypeName { get; set; }

        public virtual ICollection<CropLoss> CropLoss { get; set; }
        public virtual ICollection<CropLosses> CropLosses { get; set; }
    }
}
