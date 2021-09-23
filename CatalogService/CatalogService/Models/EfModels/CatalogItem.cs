using System;
using System.Collections.Generic;

#nullable disable

namespace CatalogService.Models
{
    public partial class CatalogItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picturefilename { get; set; }
        public long BrandId { get; set; }
        public long TypeId { get; set; }

        public virtual CatalogBrand Brand { get; set; }
        public virtual CatalogType Type { get; set; }
    }
}
