using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.DataAccess
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Dbo.CBrand, Models.CatalogBrand>();
            CreateMap<Models.CatalogBrand, Models.Dbo.CBrand>();

            CreateMap<Models.Dbo.CItem, Models.CatalogItem>();
            CreateMap<Models.CatalogItem, Models.Dbo.CItem>();

            CreateMap<Models.Dbo.CType, Models.CatalogType>();
            CreateMap<Models.CatalogType, Models.Dbo.CType>();

            CreateMap<Models.Dbo.CItem, item>();
            CreateMap<item, Models.Dbo.CItem>();
        }
    }
}
