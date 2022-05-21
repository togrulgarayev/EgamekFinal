using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Egamek_Core.Entities;

namespace Egamek_Business.Interfaces
{
    public interface IGenderService
    {
        Task<List<Gender>> GetAllAsync();
        Task<Gender> Get(int id);
        Task Remove(int id);
    }
}
