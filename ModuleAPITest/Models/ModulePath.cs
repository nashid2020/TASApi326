using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models
{
    public partial class ModulePath
    {
        public ModulePath()
        {
            MachineVersionsModulePath = new HashSet<MachineVersionsModulePath>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<MachineVersionsModulePath> MachineVersionsModulePath { get; set; }
    }
}
