using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ScenariosSubitem
    {
        public ScenariosSubitem()
        {
            ScenariosDetailsYearwise = new HashSet<ScenariosDetailsYearwise>();
        }

        public int ScenariosSubitemId { get; set; }
        public string ScenariosSubitemName { get; set; }
        public string ScenariosSubitemUnit { get; set; }
        public string ScenariosSubitemDescription { get; set; }

        public virtual ICollection<ScenariosDetailsYearwise> ScenariosDetailsYearwise { get; set; }
    }
}
