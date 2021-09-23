using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Models.Dbo
{
    public class CItem : IObjectWithId
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picturefilename { get; set; }
        public long BrandId { get; set; }
        public long TypeId { get; set; }
    }
}
