using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class StategiesType
    {
        public StategiesType()
        {
            Strategies = new HashSet<Strategies>();
        }

        public int StategiesTypeCode { get; set; }
        public string StategiesTypeName { get; set; }

        public virtual ICollection<Strategies> Strategies { get; set; }
    }
}
