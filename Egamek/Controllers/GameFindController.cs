using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.HomeViewModel;
using Egamek_Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Business.ViewModels.FindGameViewModel;

namespace Egamek.Controllers
{
    public class GameFindController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ICommonCategoryService _commonCategoryService;
        private readonly IGameCategoryService _gameCategoryService;
        private readonly IUnitOfWork _unitOfWork;
        public GameFindController(ICommonCategoryService commonCategoryService,IGameCategoryService gameCategoryService,IGameService gameService, IUnitOfWork unitOfWork)
        {
            _gameService = gameService;
            _unitOfWork = unitOfWork;
            _commonCategoryService = commonCategoryService;
            _gameCategoryService = gameCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var game = await _gameService.GetAllAsync();
            var findGameViewModel = new FindGameViewModel()
            {
                Game = game
            };
            return View(findGameViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string gameSearch)
        {
            ViewData["SearchedGame"] = gameSearch;
            //var productImage = await _productImageService.GetAllAsync();
            var gameQuery = from p in await _unitOfWork.gameRepository.GetAllAsync(p => p.IsDeleted == false) select p;
            if (!String.IsNullOrEmpty(gameSearch))
            {
                gameQuery =
                    gameQuery.Where(p => p.Name.Trim().ToLower().Contains(gameSearch.Trim().ToLower()) || p.GameCategory.Name.Trim().ToLower().Contains(gameSearch.Trim().ToLower()) || p.CommonCategory.Name.Trim().ToLower().Contains(gameSearch.Trim().ToLower()));
            }
            //var pageProduct = await _productService.GetAllPaginatedAsync(page);
            //var Product = gameQuery.ToList();
            //return View(Product);


            var findGameViewModel = new FindGameViewModel()
            {
                Game = gameQuery.ToList(),
                GameCategory = await _gameCategoryService.GetAllAsync(),
                CommonCategory = await _commonCategoryService.GetAllAsync()

            };
            return View(findGameViewModel);

        }
    }
}
