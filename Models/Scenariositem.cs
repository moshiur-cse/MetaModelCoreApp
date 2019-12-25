using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Scenariositem
    {
        public Scenariositem()
        {
            ScenariosDetailsYearwise = new HashSet<ScenariosDetailsYearwise>();
        }

        public int ScenariositemId { get; set; }
        public string ScenariositemName { get; set; }

        public virtual ICollection<ScenariosDetailsYearwise> ScenariosDetailsYearwise { get; set; }
    }
}
