using Egamek_Core.Entities;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Repositories.Implementations
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
