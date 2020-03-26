using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.DB
{
    public partial class Topic
    {
        public Topic()
        {
            Package = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Package> Package { get; set; }
    }
}
