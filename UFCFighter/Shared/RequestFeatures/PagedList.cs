using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class PagedList<UFCFighterDto>:List<UFCFighterDto>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<UFCFighterDto> items,int count,int pageNumber,int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize=pageSize,
                CurrentPage=pageNumber,
                TotalPages=(int) Math.Ceiling(count/(double)pageSize)
            };

            AddRange(items);
        }
        public static PagedList<UFCFighterDto> ToPagedList(IEnumerable<UFCFighterDto> source,int pageNumber,int pageSize) {
            var count=source.Count();
            var items=source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();

            return new PagedList<UFCFighterDto>(items, count, pageNumber, pageSize);
        }
    }
}
