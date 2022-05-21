using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.GameCategoryViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Implementations
{
    public class GameCategoryService : IGameCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public GameCategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        public async Task Create(GameCategoryCreateViewModel gameCategoryCreateViewModel)
        {
            var newGameCategory = new GameCategory()
            {
                Name = gameCategoryCreateViewModel.Name
            };

            await _unitOfWork.gameCategoryRepository.CreateAsync(newGameCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task<GameCategory> Get(int id)
        {
            return await _unitOfWork.gameCategoryRepository.Get(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<List<GameCategory>> GetAllAsync()
        {
            return await _unitOfWork.gameCategoryRepository.GetAllAsync(g => g.IsDeleted == false);
        }

        public async Task Remove(int id)
        {
            var delete = await _unitOfWork.gameCategoryRepository.Get(g => g.Id == id && g.IsDeleted == false);
            delete.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, GameCategoryUpdateViewModel gameCategoryUpdateViewModel)
        {
            GameCategory dbGameCategory = await _unitOfWork.gameCategoryRepository.Get(c => c.Id == id);

            dbGameCategory.Name = gameCategoryUpdateViewModel.Name;

            await _unitOfWork.SaveAsync();
        }
    }
}
