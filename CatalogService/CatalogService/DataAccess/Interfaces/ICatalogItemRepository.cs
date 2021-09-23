using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.DataAccess.Interfaces
{
    public interface ICatalogItemRepository : IRepository<Models.CatalogItem, Models.Dbo.CItem>
    {
        Models.Dbo.CItem FindById(long id);
    }
}
