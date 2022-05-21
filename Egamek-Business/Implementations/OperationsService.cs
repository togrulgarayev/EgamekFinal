using Egamek_Business.Interfaces;
using Egamek_Business.ViewModels.OperationViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Implementations
{
    public class OperationsService : IOperationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public OperationsService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<Operations> Get(int id)
        {
            return await _unitOfWork.operationsRepository.Get(po => po.Id == id);
        }

        public async Task<List<Operations>> GetAllAsync(string userId)
        {
            return await _unitOfWork.operationsRepository.GetAllAsync(po =>po.ApplicationUserId == userId);
        }
        

        public async Task<List<Operations>> GetAllFavouriteAsync(string userId)
        {
            return await _unitOfWork.operationsRepository.GetAllAsync(po => po.ApplicationUserId == userId && po.IsFavourite == true);
        }

        public async Task<List<Operations>> GetAllFavouriteGameAsync()
        {
            return await _unitOfWork.operationsRepository.GetAllAsync(po => po.IsFavourite == true);
        }

        public async Task SetFavourite(int gameId, string userid)
        {

            var gameOperation = new Operations()
            {
                GameId = gameId,
                ApplicationUserId = userid,
                IsFavourite = true
            };

            await _unitOfWork.operationsRepository.CreateAsync(gameOperation);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteFavourite(int gameId, string userid)
        {
            var dbGameOperation =
                await _unitOfWork.operationsRepository.Get(po =>
                    po.GameId == gameId && po.ApplicationUserId == userid && po.IsFavourite == true);

            //dbGameOperation.IsFavourite = false;

            _unitOfWork.operationsRepository.Remove(dbGameOperation);
            //_unitOfWork.operationsRepository.Update(dbGameOperation);
            await _unitOfWork.SaveAsync();
        }
    }
}
