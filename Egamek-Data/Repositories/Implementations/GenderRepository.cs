using System;
using System.Collections.Generic;
using System.Text;
using Egamek_Core.Entities;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;

namespace Egamek_Data.Repositories.Implementations
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        private readonly AppDbContext _context;
        public GenderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
