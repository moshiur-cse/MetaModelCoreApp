using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class ProjectWiseProgram
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProgramCode { get; set; }

        public virtual Program ProgramCodeNavigation { get; set; }
        public virtual Projects ProjectCodeNavigation { get; set; }
    }
}
