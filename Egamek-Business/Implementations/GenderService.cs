using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Egamek_Business.Interfaces;
using Egamek_Core;
using Egamek_Core.Entities;

namespace Egamek_Business.Implementations
{
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Gender>> GetAllAsync()
        {

            return await _unitOfWork.genderRepository.GetAllAsync();
        }

        public async Task<Gender> Get(int id)
        {
            return await _unitOfWork.genderRepository.Get(p => p.Id == id);
        }

        public async Task Remove(int id)
        {
            Gender dbGender = await _unitOfWork.genderRepository.Get(c => c.Id == id);



            _unitOfWork.genderRepository.Remove(dbGender);
            await _unitOfWork.SaveAsync();
        }
    }
}
