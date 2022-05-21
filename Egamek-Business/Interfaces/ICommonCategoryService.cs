using Egamek_Business.ViewModels.CommonCategoryViewModels;
using Egamek_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Business.Interfaces
{
    public interface ICommonCategoryService
    {
        Task<List<CommonCategory>> GetAllAsync();
        Task<CommonCategory> Get(int id);
        Task Create(CommonCategoryCreateViewModel commonCategoryCreateViewModel);
        Task Update(int id, CommonCategoryUpdateViewModel commonCategoryUpdateViewModel);
        Task Remove(int id);
    }
}
