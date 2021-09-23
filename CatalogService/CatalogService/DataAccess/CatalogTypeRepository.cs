using AutoMapper;
using CatalogService.DataAccess.Interfaces;
using CatalogService.Models.Dbo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.DataAccess
{
    public class CatalogTypeRepository : Repository<Models.CatalogType, Models.Dbo.CType>, ICatalogTypeRepository
    {
        public CatalogTypeRepository(Models.CatalogServiceContext catalogServiceContext, ILogger<CatalogTypeRepository> logger, IMapper mapper) : base(catalogServiceContext, logger, mapper)
        {

        }

        public CType FindById(long id)
        {
            try
            {
                Models.CatalogType brand = _context.CatalogTypes.FirstOrDefault(x => x.Id.Equals(id));
                var res = _mapper.Map<Models.CatalogType, Models.Dbo.CType>(brand);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
