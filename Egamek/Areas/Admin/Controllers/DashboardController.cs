using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Egamek_Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Egamek_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Egamek_Business.ViewModels.StatisticViewModels;

namespace Egamek.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IGameService _gameService;
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(IGameService gameService, UserManager<ApplicationUser> userManager)
        {
            _gameService = gameService;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllAsync();
            var users = await _userManager.Users.ToListAsync();


            var stats = new StatisticViewModel
            {
                GameCount = games.Count,
                UserCount = users.Count
            };
            return View(stats);
        }
    }
}
