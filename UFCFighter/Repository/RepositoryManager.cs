using Contracts;
using Repository.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly UFCFightersContext _dbContext;
        private readonly Lazy<IUFCFighterRepository> _fighterRepository;

        public RepositoryManager(UFCFightersContext dbContext)
        {
            _dbContext = dbContext;
            _fighterRepository = new Lazy<IUFCFighterRepository>(() => new UFCFighterRepository(_dbContext));
        }
        public IUFCFighterRepository Fighter => _fighterRepository.Value;

    }
}
