using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPITest.Models
{
    public class VersionIngestModel
    {
        public int Id { get; set; }
        public string versionName { get; set; }
        public string help { get; set; }
        //public List<string> parent { get; set; }
        public string path { get; set; }
        public string full { get; set; }
        public string canonicalVersionString { get; set; }

        public int PackageIngestModel { get; set; }

        public virtual PackageIngestModel Package { get; set; }
    }
}
