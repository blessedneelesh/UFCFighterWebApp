using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUFCFighterService> _fighterService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager logger) {
            _fighterService = new Lazy<IUFCFighterService>(() =>
                   new UFCFighterService(repositoryManager, logger));
        }

        public IUFCFighterService FighterService => _fighterService.Value;

    }
}
