using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.HomeViewModel;
using Egamek_Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egamek.Controllers
{
    public class FindGameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IUnitOfWork _unitOfWork;
        public FindGameController(IGameService gameService, IUnitOfWork unitOfWork)
        {
            _gameService = gameService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        
    }
}
