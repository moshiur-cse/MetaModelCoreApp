using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class BdDistricts
    {
        public int Gid { get; set; }
        public long? Objectid { get; set; }
        public string DivisionC { get; set; }
        public string DistrictC { get; set; }
        public string DistrictN { get; set; }
        public decimal? ShapeLeng { get; set; }
        public decimal? ShapeArea { get; set; }
        public long? Id { get; set; }
        public string District1 { get; set; }
        public int? DistClass { get; set; }
        public int? ZoneClass { get; set; }
    }
}
