using Egamek_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Egamek_Core
{
    public interface IUnitOfWork
    {
        public IGameRepository gameRepository { get; }
        public ICommonCategoryRepository commonCategoryRepository { get; }
        public IGameCategoryRepository gameCategoryRepository { get; }
        public IOperationsRepository operationsRepository { get; }
        public IGenderRepository genderRepository { get; }
        Task SaveAsync();
    }
}
