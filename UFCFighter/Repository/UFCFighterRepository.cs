using Contracts;
using Repository.Models.DataLayer;
using Repository.Queries;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UFCFighterRepository : IUFCFighterRepository
    {
        private readonly UFCFightersContext dbContext;

        public UFCFighterRepository(UFCFightersContext ufcContext) { 
        dbContext= ufcContext;
        }
        public List<UFCFighterDto> GetAllUFCFighters()
        {
            // var query = UFCQuery.selectUFCFighterQuery;
            
            var lst = (from n in dbContext.Fighters
                       select new UFCFighterDto   // where n.Division == fighterParameters.Division
                       {
                           fid = n.Fid,
                           name = n.Name,
                           nick = n.Nick,
                           birth_date = n.BirthDate,
                           height= n.Height,
                           weight=n.Weight,
                           association=n.Association,
                           division=n.Division,
                           locality=n.Locality,
                           country=n.Country,
                           url=n.Url,
                       }
                     ).ToList();
            return lst;
        }

        //return is pagedList (calling pagedList.ToPagedList)
        public PagedList<UFCFighterDto> GetAllUFCFighters(FighterParameters fighterParameters)
        {
            IQueryable<Fighter> query = dbContext.Fighters;
            if (!string.IsNullOrEmpty(fighterParameters.Division)){ 
                query=query.Where(div=>div.Division == fighterParameters.Division);
            }
            if (!string.IsNullOrEmpty(fighterParameters.Country))
            {
                query = query.Where(div => div.Country == fighterParameters.Country);
            }
            if (!string.IsNullOrWhiteSpace(fighterParameters.SearchTerm))
            {
                var lowerCaseTerm=fighterParameters.SearchTerm.ToLower();
                query = query.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
            }


            var lst = query.Select(n =>
             new UFCFighterDto
             {
                 fid = n.Fid,
                 name = n.Name,
                 nick = n.Nick,
                 birth_date = n.BirthDate,
                 height = n.Height,
                 weight = n.Weight,
                 association = n.Association,
                 division = n.Division,
                 locality = n.Locality,
                 country = n.Country,
                 url = n.Url,
             });
            return PagedList<UFCFighterDto>.ToPagedList(lst, fighterParameters.PageNumber,fighterParameters.PageSize);
  
        }

       public List<string> GetCountry()
        {
           var uniqueCountries=GetAllUFCFighters().Select(p=>p.country).Distinct().ToList();
           return uniqueCountries;
        }

        public List<string> GetDivision()
        {
            var uniqueDivision = GetAllUFCFighters().Select(p => p.division).Distinct().ToList();
            return uniqueDivision;
        }
    }
}
