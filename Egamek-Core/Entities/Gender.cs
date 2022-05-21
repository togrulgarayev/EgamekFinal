using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Core.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> ApplicationUser { get; set; }
    }
}
