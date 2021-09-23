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
    public class CatalogBrandRepository: Repository<Models.CatalogBrand, Models.Dbo.CBrand>, ICatalogBrandRepository
    {
        public CatalogBrandRepository(Models.CatalogServiceContext catalogServiceContext, ILogger<CatalogBrandRepository> logger, IMapper mapper) : base(catalogServiceContext, logger, mapper)
        {

        }

        public CBrand FindById(long id)
        {
            try
            {
                Models.CatalogBrand brand = _context.CatalogBrands.FirstOrDefault(x => x.Id.Equals(id));
                var res = _mapper.Map<Models.CatalogBrand, Models.Dbo.CBrand>(brand);
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
