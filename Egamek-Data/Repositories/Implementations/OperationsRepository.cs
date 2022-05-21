using Egamek_Core.Entities;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egamek_Data.Repositories.Implementations
{
    internal class OperationsRepository : Repository<Operations>, IOperationsRepository
    {
        private readonly AppDbContext _context;
        public OperationsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
