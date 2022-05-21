using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Core.Entities
{
    public class CommonCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; }
        public List<Game> Games { get; set; }
    }
}

