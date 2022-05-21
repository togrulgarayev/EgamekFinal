using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Egamek_Core;
using Egamek_Core.Interfaces;
using Egamek_Data.DAL;
using Egamek_Data.Repositories.Implementations;

namespace Egamek_Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGameRepository _gameRepository;
        private ICommonCategoryRepository _commonCategoryRepository;
        private IGameCategoryRepository _gameCategoryRepository;
        private IOperationsRepository _operationsRepository;
        private IGenderRepository _genderRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IGameRepository gameRepository => _gameRepository = _gameRepository ?? new GameRepository(_context);
        public IOperationsRepository operationsRepository => _operationsRepository = _operationsRepository ?? new OperationsRepository(_context);
        public IGenderRepository genderRepository => _genderRepository = _genderRepository ?? new GenderRepository(_context);
        public IGameCategoryRepository gameCategoryRepository => _gameCategoryRepository = _gameCategoryRepository ?? new GameCategoryRepository(_context);
        public ICommonCategoryRepository commonCategoryRepository => _commonCategoryRepository = _commonCategoryRepository ?? new CommonCategoryRepository(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
