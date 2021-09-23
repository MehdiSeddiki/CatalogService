using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.DataAccess.Interfaces
{
    public interface ICatalogBrandRepository : IRepository<Models.CatalogBrand, Models.Dbo.CBrand>
    {
        Models.Dbo.CBrand FindById(long id);
    }
}
