using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Egamek_Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iframe { get; set; }
        public bool IsDeleted { get; set; }
        public string OperatingSystem { get; set; }
        public string Processor { get; set; }
        public string VideoCard { get; set; }
        public string Ram { get; set; }
        public string Space { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime CreateTime { get; set; }
        public int CommonCategoryId { get; set; }
        public CommonCategory CommonCategory { get; set; }
        public int GameCategoryId { get; set; }
        public GameCategory GameCategory { get; set; }
    }
}
