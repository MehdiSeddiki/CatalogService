using System;
using System.Collections.Generic;

#nullable disable

namespace CatalogService.Models
{
    public partial class CatalogType
    {
        public CatalogType()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public long Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
