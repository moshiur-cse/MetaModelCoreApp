using System;
using System.Collections.Generic;

namespace MetaModelCoreApp.Models
{
    public partial class Projects
    {
        public Projects()
        {
            AgencyProjects = new HashSet<AgencyProjects>();
            MinistryProjects = new HashSet<MinistryProjects>();
            ProjectPointLocation = new HashSet<ProjectPointLocation>();
            ProjectWiseProgram = new HashSet<ProjectWiseProgram>();
            ProjectWithBdpGoals = new HashSet<ProjectWithBdpGoals>();
            ProjectWithSdgGoals = new HashSet<ProjectWithSdgGoals>();
            ProjectWithStrategies = new HashSet<ProjectWithStrategies>();
        }

        public int SlNo { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectObjectives { get; set; }
        public double? EstimatedCost { get; set; }
        public string ProjectIntervention { get; set; }
        public double? Duration { get; set; }
        public string Benefits { get; set; }
        public string District { get; set; }
        public string Upazila { get; set; }
        public string ResponsibleMinistry { get; set; }
        public string ExecutingAgency { get; set; }
        public string Hotspot { get; set; }
        public int? IsProjectActive { get; set; }

        public virtual ICollection<AgencyProjects> AgencyProjects { get; set; }
        public virtual ICollection<MinistryProjects> MinistryProjects { get; set; }
        public virtual ICollection<ProjectPointLocation> ProjectPointLocation { get; set; }
        public virtual ICollection<ProjectWiseProgram> ProjectWiseProgram { get; set; }
        public virtual ICollection<ProjectWithBdpGoals> ProjectWithBdpGoals { get; set; }
        public virtual ICollection<ProjectWithSdgGoals> ProjectWithSdgGoals { get; set; }
        public virtual ICollection<ProjectWithStrategies> ProjectWithStrategies { get; set; }
    }
}
