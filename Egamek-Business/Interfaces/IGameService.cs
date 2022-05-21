using Egamek_Business.ViewModels.GameViewModels;
using Egamek_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Interfaces
{
    public interface IGameService
    {
        Task<List<Game>> GetAllAsync();
        Task<Game> Get(int id);
        Task Create(GameCreateViewModel gameViewModel);
        Task Update(int id, GameUpdateViewModel gameViewModel);
        Task Remove(int id);
    }

}
