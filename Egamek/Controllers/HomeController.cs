using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.GameCategoryViewModels;
using Egamek_Business.ViewModels.HomeViewModel;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Egamek.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IOperationsService _operationsService;
        private readonly ICommonCategoryService _commonCategoryService;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager,IOperationsService operationsService,IGameService gameService,  ICommonCategoryService commonCategoryService)
        {
            _gameService = gameService;
            _commonCategoryService = commonCategoryService;
            _operationsService = operationsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var homeViewModel = new HomeViewModel()
            {
                Game = await _gameService.GetAllAsync(),
                CommonCategory = await  _commonCategoryService.GetAllAsync(),
                Operations = await _operationsService.GetAllFavouriteAsync(userId)
            };

            return View(homeViewModel);
        }


        [Authorize]
        public async Task<IActionResult> SetFavourite(int id, string ReturnUrl)
        {

            var userId = _userManager.GetUserId(HttpContext.User);

            await _operationsService.SetFavourite(id, userId);

            if (ReturnUrl != null)
            {

                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public async Task<IActionResult> DeleteFavourite(int id)
        {

            var userId = _userManager.GetUserId(HttpContext.User);

            await _operationsService.DeleteFavourite(id, userId);


            return RedirectToAction("Index","Home");
        }
    }
}
