using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class LegendInfo
    {
        public int Id { get; set; }
        public string LengentName { get; set; }
        public int LengentNameId { get; set; }
        public long StartRange { get; set; }
        public long EndRange { get; set; }
        public string LegendColor { get; set; }
    }
}
