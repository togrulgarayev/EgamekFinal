using Egamek_Business.ViewModels.GameCategoryViewModels;
using Egamek_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Interfaces
{
    public interface IGameCategoryService
    {
        Task<List<GameCategory>> GetAllAsync();
        Task<GameCategory> Get(int id);
        Task Create(GameCategoryCreateViewModel gameCategoryCreateViewModel);
        Task Update(int id, GameCategoryUpdateViewModel gameCategoryUpdateViewModel);
        Task Remove(int id);
    }
}
