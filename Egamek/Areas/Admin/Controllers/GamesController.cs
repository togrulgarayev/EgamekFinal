using Egamek_Business.Interfaces;
using Egamek_Business.Utilities;
using Egamek_Business.ViewModels.GameViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Egamek.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGameCategoryService _gameCategoryService;
        private readonly ICommonCategoryService _commonCategoryService;
        private readonly IUnitOfWork _unitOfWork;
        public GamesController(IGameService gameService, IUnitOfWork unitOfWork, IGameCategoryService gameCategoryService, ICommonCategoryService commonCategoryService)
        {
            _gameService = gameService;
            _unitOfWork = unitOfWork;
            _gameCategoryService = gameCategoryService;
            _commonCategoryService = commonCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var gameViewModel = new GameViewModel()
            {
                Game = await _gameService.GetAllAsync(),
                GameCategory = await _gameCategoryService.GetAllAsync(),
                CommonCategory = await _commonCategoryService.GetAllAsync(),
            };
            
            return View(gameViewModel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.gameCategory = await _gameCategoryService.GetAllAsync();
            ViewBag.commonCategory = await _commonCategoryService.GetAllAsync();
            ViewBag.game = await _gameService.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameCreateViewModel gameCreateViewModel)
        {
            ViewBag.gameCategory = await _gameCategoryService.GetAllAsync();
            ViewBag.commonCategory = await _commonCategoryService.GetAllAsync();
            ViewBag.game = await _gameService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (!gameCreateViewModel.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFiles", "The file you select must be of image type! ");
                    return View(gameCreateViewModel);
                }

                if (!gameCreateViewModel.Photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("ImageFiles", "The size of the selected file should not exceed 500 kb !");
                    return View(gameCreateViewModel);
                }
                await _gameService.Create(gameCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.gameCategory = await _gameCategoryService.GetAllAsync();
            ViewBag.commonCategory = await _commonCategoryService.GetAllAsync();
            ViewBag.game = await _gameService.GetAllAsync();

            Game game = await _gameService.Get(id);
            if (game == null)
            {
                return NotFound();
            }
            var gameUpdateViewModel = new GameUpdateViewModel()
            {
                Name = game.Name,
                Iframe = game.Iframe,
                Description = game.Description,
                OperatingSystem = game.OperatingSystem,
                Processor = game.Processor,
                VideoCard = game.VideoCard,
                Ram = game.Ram,
                Space = game.Space,
                CommonCategoryId = game.CommonCategoryId,
                GameCategoryId = game.GameCategoryId,
            };
            return View(gameUpdateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,GameUpdateViewModel gameUpdateViewModel)
        {
            if (ModelState.IsValid)
            {

                if (gameUpdateViewModel.Photo != null)
                {
                    if (!gameUpdateViewModel.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("ImageFiles", "The file you select must be of image type! ");
                        return View(gameUpdateViewModel);
                    }

                    if (!gameUpdateViewModel.Photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("ImageFiles", "The size of the selected file should not exceed 500 kb !");
                        return View(gameUpdateViewModel);
                    }
                }
                
                await _gameService.Update(id,gameUpdateViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.gameCategory = await _gameCategoryService.GetAllAsync();
            ViewBag.commonCategory = await _commonCategoryService.GetAllAsync();
            ViewBag.game = await _gameService.GetAllAsync();
            return View(gameUpdateViewModel);
        }
    }
}
