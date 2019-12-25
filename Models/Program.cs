using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Program
    {
        public Program()
        {
            ProjectWiseProgram = new HashSet<ProjectWiseProgram>();
        }

        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public int? SlNo { get; set; }

        public virtual ICollection<ProjectWiseProgram> ProjectWiseProgram { get; set; }
    }
}
