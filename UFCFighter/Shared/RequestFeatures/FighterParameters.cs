using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class FighterParameters: RequestParameters
    {
        public string? Division { get; set; }
        public string? SearchTerm { get; set; }
        public string? Country { get; set; }
    }
}
