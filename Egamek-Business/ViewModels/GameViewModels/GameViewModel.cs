using Egamek_Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Business.ViewModels.GameViewModels
{
    public class GameViewModel
    {
        public List<Game> Game { get; set; }
        public List<CommonCategory> CommonCategory { get; set; }
        public List<GameCategory> GameCategory { get; set; }
    }
}
