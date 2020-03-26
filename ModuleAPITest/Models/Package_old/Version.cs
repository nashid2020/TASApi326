using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.Package_old
{
    public partial class Version
    {
        public Version()
        {
            MachineVersion = new HashSet<MachineVersion>();
        }

        public int Id { get; set; }
        public string VersionName { get; set; }
        public string Help { get; set; }
        public string Path { get; set; }
        public string FullName { get; set; }
        public string CanonicalVersionString { get; set; }
        public int PackageId { get; set; }

        public virtual Package Package { get; set; }
        public virtual ICollection<MachineVersion> MachineVersion { get; set; }
    }
}
