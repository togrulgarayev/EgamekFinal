using Egamek_Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Business.ViewModels.GameViewModels
{
    public class GameUpdateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iframe { get; set; }
        public string OperatingSystem { get; set; }
        public string Processor { get; set; }
        public string VideoCard { get; set; }
        public string Ram { get; set; }
        public string Space { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
        public int CommonCategoryId { get; set; }
        public int GameCategoryId { get; set; }
        public List<CommonCategory> CommonCategory { get; set; }
        public List<GameCategory> GameCategory { get; set; }
    }
}
