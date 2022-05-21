using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.CommonCategoryViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Implementations
{
    public class CommonCategoryService : ICommonCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public CommonCategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public async Task Create(CommonCategoryCreateViewModel commonCategoryCreateViewModel)
        {
            var newCommonCategory = new CommonCategory()
            {
                Name = commonCategoryCreateViewModel.Name
            };

            await _unitOfWork.commonCategoryRepository.CreateAsync(newCommonCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CommonCategory> Get(int id)
        {
            return await _unitOfWork.commonCategoryRepository.Get(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<List<CommonCategory>> GetAllAsync()
        {
            return await _unitOfWork.commonCategoryRepository.GetAllAsync(g => g.IsDeleted == false);
        }

        public async Task Remove(int id)
        {
            var delete = await _unitOfWork.commonCategoryRepository.Get(g => g.Id == id && g.IsDeleted == false);
            delete.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, CommonCategoryUpdateViewModel commonCategoryUpdateViewModel)
        {
            CommonCategory dbCommonCategory = await _unitOfWork.commonCategoryRepository.Get(c => c.Id == id);

            dbCommonCategory.Name = commonCategoryUpdateViewModel.Name;

            await _unitOfWork.SaveAsync();
        }
    }
}
