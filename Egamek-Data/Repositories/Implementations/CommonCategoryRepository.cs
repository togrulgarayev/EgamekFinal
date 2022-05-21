using Egamek_Core.Entities;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Repositories.Implementations
{
    public class CommonCategoryRepository : Repository<CommonCategory>, ICommonCategoryRepository
    {
        private readonly AppDbContext _context;
        public CommonCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
