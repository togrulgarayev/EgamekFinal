using Egamek_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Business.ViewModels.GameDetailViewModel
{
    public class GameDetailViewModel
    {
        public Game Game { get; set; }
        public List<Operations> Operations { get; set; }
    }
}
