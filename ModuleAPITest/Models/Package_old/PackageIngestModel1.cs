using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPITest.Models.Package_old
{
    public class PackageIngestModel1
    {
        public PackageIngestModel1()
        {
            versions = new HashSet<VersionIngestModel1>();
        }
        public int Id { get; set; }
        public string package { get; set; }
        public string categories { get; set; }
        public string url { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string defaultVersionName { get; set; }
        
        public virtual ICollection<VersionIngestModel1> versions { get; set; }
    }
}
