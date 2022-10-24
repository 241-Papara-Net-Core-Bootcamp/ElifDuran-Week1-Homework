using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owner.API.Modal
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }
        public string Type { get; set; }

    }
}
