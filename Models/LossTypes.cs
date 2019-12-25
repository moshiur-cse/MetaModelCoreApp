using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class LossTypes
    {
        public LossTypes()
        {
            CropLoss = new HashSet<CropLoss>();
            CropLosses = new HashSet<CropLosses>();
        }

        public int Id { get; set; }
        public string LossTypeName { get; set; }

        public virtual ICollection<CropLoss> CropLoss { get; set; }
        public virtual ICollection<CropLosses> CropLosses { get; set; }
    }
}
