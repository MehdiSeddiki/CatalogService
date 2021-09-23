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
    public class CatalogItemRepository : Repository<Models.CatalogItem, Models.Dbo.CItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(Models.CatalogServiceContext catalogServiceContext, ILogger<CatalogItemRepository> logger, IMapper mapper) : base(catalogServiceContext, logger, mapper)
        {

        }

        public CItem FindById(long id)
        {
            try
            {
                Models.CatalogItem brand = _context.CatalogItems.FirstOrDefault(x => x.Id.Equals(id));
                var res = _mapper.Map<Models.CatalogItem, Models.Dbo.CItem>(brand);
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
