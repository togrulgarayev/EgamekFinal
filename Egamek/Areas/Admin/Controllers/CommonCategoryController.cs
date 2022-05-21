using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.CommonCategoryViewModels;
using Egamek_Business.ViewModels.GameCategoryViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Egamek.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CommonCategoryController : Controller
    {
        private readonly ICommonCategoryService _commonCategoryService;
        private readonly IUnitOfWork _unitOfWork;
        public CommonCategoryController(IUnitOfWork unitOfWork, ICommonCategoryService commonCategoryService)
        {
            _commonCategoryService = commonCategoryService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var commonCategoryViewModel = new CommonCategoryViewModel()
            {
                CommonCategory = await _commonCategoryService.GetAllAsync(),
            };

            return View(commonCategoryViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommonCategoryCreateViewModel commonCategoryViewModel)
        {

            await _commonCategoryService.Create(commonCategoryViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Update(int id)
        {
            CommonCategory commonCategory = await _commonCategoryService.Get(id);

            if (commonCategory == null) return NotFound();


            var commonCategoryViewModel = new CommonCategoryUpdateViewModel()
            {
                Name = commonCategory.Name

            };



            return View(commonCategoryViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, CommonCategoryUpdateViewModel commonCategoryViewModel)
        {
            await _commonCategoryService.Update(id, commonCategoryViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _commonCategoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
