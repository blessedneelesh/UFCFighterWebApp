using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUFCFighterService
    {
        List<UFCFighterDto> GetAllUFCFighters();
        (List<UFCFighterDto> fighters,MetaData metaData) GetAllUFCFighters(FighterParameters fighterParameter);
        List<string> GetDistinctCountries();
        List<string> GetDistinctDivision();
    }
}
