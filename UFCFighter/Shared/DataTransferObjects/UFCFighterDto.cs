using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class UFCFighterDto
    {
        public int fid {  get; set; }
        public string name { get; set; }
        public string? nick { get;set; }
        public DateTime? birth_date { get; set; }
        public decimal? height { get; set; }
        public decimal? weight { get; set; }
        public string? association { get;set; }
        public string? division { get; set; }
        public string? locality { get; set; }    
        public string? country { get; set; }
        public string? url { get; set; }
    }
}
