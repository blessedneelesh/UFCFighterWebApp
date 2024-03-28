using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UFCFighterService : IUFCFighterService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public UFCFighterService(IRepositoryManager repository, ILoggerManager logger) 
        {
            _repository = repository;
            _logger = logger;
        }

        public List<UFCFighterDto> GetAllUFCFighters()
        {
            try
            {
                var getUfcFighter = _repository.Fighter.GetAllUFCFighters();
                return getUfcFighter;
            }
            catch(Exception ex)
            {
                _logger.LogError("Something went wrong in the "+ nameof(GetAllUFCFighters) +" service method "+ ex);
                throw;
            }

        }

        public (List<UFCFighterDto> fighters,MetaData metaData) GetAllUFCFighters(FighterParameters fighterParameters) {
            try
            {
                var fightersWithMetadata=_repository.Fighter.GetAllUFCFighters(fighterParameters);

               // var fightersDto = _repository.Fighter.GetAllUFCFighters(fightersWithMetadata);
                return (fighters: fightersWithMetadata, metaData:fightersWithMetadata.MetaData);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong in the " + nameof(GetAllUFCFighters) + " service method " + ex);
                throw;
            }
        }

        public List<string> GetDistinctCountries()
        {
            try
            {
                var distinctCountries = _repository.Fighter.GetCountry();
                return distinctCountries;
            }
            catch(Exception ex)
            {
                _logger.LogError("Something went wrong in the " + nameof(GetDistinctCountries) + " service method " + ex);
                throw;
            }
        }

        public List<string> GetDistinctDivision()
        {
            try
            {
                var distinctCountries = _repository.Fighter.GetDivision();
                return distinctCountries;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong in the " + nameof(GetDistinctDivision) + " service method " + ex);
                throw;
            }
        }
        
    }
}
