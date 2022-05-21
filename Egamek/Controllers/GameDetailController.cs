using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.GameDetailViewModel;
using Egamek_Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Egamek.Controllers
{
    public class GameDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameService _gameService;
        private readonly IOperationsService _operationsService;
        private readonly UserManager<ApplicationUser> _userManager;
        public GameDetailController(UserManager<ApplicationUser> userManager,IOperationsService operationsService,IUnitOfWork unitOfWork, IGameService gameService)
        {
            _unitOfWork = unitOfWork;
            _gameService = gameService;
            _operationsService = operationsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var gameDetailViewModel = new GameDetailViewModel()
            {
                Game = await _gameService.Get(id),
                Operations = await _operationsService.GetAllFavouriteAsync(userId)
            };

            return View(gameDetailViewModel);
        }
    }
}
