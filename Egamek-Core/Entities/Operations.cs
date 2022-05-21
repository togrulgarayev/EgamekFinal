using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Core.Entities
{
    public class Operations
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public bool IsFavourite { get; set; }
    }
}
