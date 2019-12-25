using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ScenariosDetailsYearwise
    {
        public int ScenariosDetailsId { get; set; }
        public int ScenariosItemId { get; set; }
        public int ScenariosSubitemId { get; set; }
        public int ScenariosId { get; set; }
        public decimal? _2015 { get; set; }
        public decimal? _2020 { get; set; }
        public decimal? _2030 { get; set; }
        public decimal? _2040 { get; set; }
        public decimal? _2050 { get; set; }
        public decimal? _2100 { get; set; }

        public virtual Senarios Scenarios { get; set; }
        public virtual Scenariositem ScenariosItem { get; set; }
        public virtual ScenariosSubitem ScenariosSubitem { get; set; }
    }
}
