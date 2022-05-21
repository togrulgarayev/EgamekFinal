using Egamek_Business.ViewModels.OperationViewModels;
using Egamek_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Interfaces
{
    public interface IOperationsService
    {
        Task<List<Operations>> GetAllAsync(string userId);
        Task<Operations> Get(int id);
        Task<List<Operations>> GetAllFavouriteAsync(string userId);
        Task<List<Operations>> GetAllFavouriteGameAsync();
        Task SetFavourite(int gameId, string userid);
        Task DeleteFavourite(int gameId, string userid);
    }
}
