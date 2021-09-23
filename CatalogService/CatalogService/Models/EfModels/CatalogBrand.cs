using System;
using System.Collections.Generic;

#nullable disable

namespace CatalogService.Models
{
    public partial class CatalogBrand
    {
        public CatalogBrand()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public long Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
