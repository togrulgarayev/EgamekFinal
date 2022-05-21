using Egamek_Business.Interfaces;
using Egamek_Business.Utilities;
using Egamek_Business.ViewModels.GameViewModels;
using Egamek_Core;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Implementations
{
    public class GameService:IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public GameService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task Create(GameCreateViewModel gameViewModel)
        {
            string gamePhoto = await gameViewModel.Photo.SaveFileAsync(_env.WebRootPath,"assets","img");
            var newGame = new Game()
            {
                Name = gameViewModel.Name,
                Iframe= gameViewModel.Iframe,
                Description = gameViewModel.Description,
                OperatingSystem = gameViewModel.OperatingSystem,
                Processor = gameViewModel.Processor,
                VideoCard = gameViewModel.VideoCard,
                Ram = gameViewModel.Ram,
                Space = gameViewModel.Space,
                CommonCategoryId = gameViewModel.CommonCategoryId,
                GameCategoryId = gameViewModel.GameCategoryId,
                Image = gamePhoto
            };
            await _unitOfWork.gameRepository.CreateAsync(newGame);
            await _unitOfWork.SaveAsync();
        }


        public async Task<Game> Get(int id)
        {
            return await _unitOfWork.gameRepository.Get(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _unitOfWork.gameRepository.GetAllAsync(g=>g.IsDeleted == false , "GameCategory" ,"CommonCategory");
        }

        public async Task Remove(int id)
        {
            var delete = await _unitOfWork.gameRepository.Get(g => g.Id == id && g.IsDeleted == false);
            delete.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, GameUpdateViewModel gameUpdateViewModel)
        {
           Game dbGame = await _unitOfWork.gameRepository.Get(g=>g.Id == id);
            dbGame.Name = gameUpdateViewModel.Name;
            dbGame.Description = gameUpdateViewModel.Description;
            dbGame.Ram = gameUpdateViewModel.Ram;
            dbGame.Space = gameUpdateViewModel.Space;
            dbGame.VideoCard = gameUpdateViewModel.VideoCard;
            dbGame.CommonCategoryId = gameUpdateViewModel.CommonCategoryId;
            dbGame.GameCategoryId = gameUpdateViewModel.GameCategoryId;
            dbGame.OperatingSystem = gameUpdateViewModel.OperatingSystem;
            dbGame.Iframe = gameUpdateViewModel.Iframe;
            dbGame.Processor = gameUpdateViewModel.Processor;

            if (gameUpdateViewModel.Photo!=null)
            {
                string fileName = await gameUpdateViewModel.Photo.SaveFileAsync(_env.WebRootPath, "assets", "img");
                dbGame.Image = fileName;
            }




            //_unitOfWork.gameRepository.Update();
            await _unitOfWork.SaveAsync();
        }
    }
}
