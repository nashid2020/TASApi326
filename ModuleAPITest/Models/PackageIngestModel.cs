using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPITest.Models
{
    public class PackageIngestModel
    {
        public int Id { get; set; }
        public string package { get; set; }
        public string categories { get; set; }
        public string url { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string defaultVersionName { get; set; }

        public ICollection<VersionIngestModel> versions { get; set; }
    }
}
