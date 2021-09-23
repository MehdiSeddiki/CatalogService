using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Models.Dbo
{
    public class CBrand : IObjectWithId
    {
        public long Id { get; set; }
        public string Brand { get; set; }
    }
}
