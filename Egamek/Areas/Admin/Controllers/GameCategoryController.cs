using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.GameCategoryViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Egamek.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class GameCategoryController : Controller
    {

        private readonly IGameCategoryService _gameCategoryService;
        private readonly IUnitOfWork _unitOfWork;
        public GameCategoryController(IUnitOfWork unitOfWork,IGameCategoryService gameCategoryService)
        {
            _gameCategoryService = gameCategoryService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var gameCategoryViewModel = new GameCategoryViewModel()
            {
                GameCategory = await _gameCategoryService.GetAllAsync(),
            };

            return View(gameCategoryViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameCategoryCreateViewModel gameCategoryViewModel)
        {

            await _gameCategoryService.Create(gameCategoryViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Update(int id)
        {
            GameCategory gameCategory = await _gameCategoryService.Get(id);

            if (gameCategory == null) return NotFound();


            var gameCategoryViewModel = new GameCategoryUpdateViewModel()
            {
                Name = gameCategory.Name

            };



            return View(gameCategoryViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, GameCategoryUpdateViewModel gameCategoryViewModel)
        {
            await _gameCategoryService.Update(id, gameCategoryViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _gameCategoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
