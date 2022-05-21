using Egamek_Core.Entities;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Repositories.Implementations
{
    internal class GameCategoryRepository : Repository<GameCategory>, IGameCategoryRepository
    {
        private readonly AppDbContext _context;
        public GameCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
