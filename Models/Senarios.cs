using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Senarios
    {
        public Senarios()
        {
            ScenariosDetailsYearwise = new HashSet<ScenariosDetailsYearwise>();
            SenarioStrategies = new HashSet<SenarioStrategies>();
        }

        public int Id { get; set; }
        public string ClimateSenarioScale { get; set; }
        public string EconomicSenarioScale { get; set; }
        public string SenarioName { get; set; }
        public string ScenarioCombineName { get; set; }
        public string ClimateImage { get; set; }
        public string EconomicImage { get; set; }

        public virtual ICollection<ScenariosDetailsYearwise> ScenariosDetailsYearwise { get; set; }
        public virtual ICollection<SenarioStrategies> SenarioStrategies { get; set; }
    }
}
