using System;
using System.Collections.Generic;
using System.Text;
using Egamek_Core.Entities;

namespace Egamek_Business.ViewModels.FindGameViewModel
{
    public class FindGameViewModel
    {
        public List<Game> Game { get; set; }
        public List<CommonCategory> CommonCategory { get; set; }
        public List<GameCategory> GameCategory { get; set; }
    }
}
