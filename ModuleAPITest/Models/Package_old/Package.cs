using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.Package_old
{
    public partial class Package
    {
        public Package()
        {
            Version = new HashSet<Version>();
        }

        public int Id { get; set; }
        public string Package1 { get; set; }
        public string Categories { get; set; }
        public string Url { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string DefaultVersionName { get; set; }

        public virtual ICollection<Version> Version { get; set; }
    }
}
