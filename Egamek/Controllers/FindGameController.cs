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

        //[HttpPost]
        //public async Task<IActionResult> Index(string gameSearch)
        //{
        //    ViewData["SearchedGame"] = gameSearch;
        //    //var productImage = await _productImageService.GetAllAsync();
        //    var gameQuery = from p in await _unitOfWork.gameRepository.GetAllAsync(p => p.IsDeleted == false) select p;
        //    if (!String.IsNullOrEmpty(gameSearch))
        //    {
        //        gameQuery =
        //            gameQuery.Where(p => p.Name.Trim().ToLower().Contains(gameSearch.Trim().ToLower()));
        //    }
        //    //var pageProduct = await _productService.GetAllPaginatedAsync(page);
        //    var Product = gameQuery.ToList();
        //    return View(Product);
        //}
    }
}
