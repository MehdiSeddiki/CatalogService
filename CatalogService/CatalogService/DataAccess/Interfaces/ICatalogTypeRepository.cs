using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.DataAccess.Interfaces
{
    public interface ICatalogTypeRepository : IRepository<Models.CatalogType, Models.Dbo.CType>
    {
        Models.Dbo.CType FindById(long id);
    }
}
