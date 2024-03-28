using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUFCFighterRepository
    {
        List<UFCFighterDto> GetAllUFCFighters();
        PagedList<UFCFighterDto> GetAllUFCFighters(FighterParameters fighterParameter);
        // PagedList<UFCFighterDto> FilterUFCFighters(FighterParameters fighterParameter);
        List<string> GetCountry();
        List<string> GetDivision();
    }
}
