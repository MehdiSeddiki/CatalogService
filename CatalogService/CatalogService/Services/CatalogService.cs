
using CatalogService.DataAccess.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService
{
    public class CatalogService : Greeter.GreeterBase
    {
        private readonly ILogger<CatalogService> _logger;
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        public CatalogService(ICatalogItemRepository catalogItemRepository, ICatalogBrandRepository catalogBrandRepository, ICatalogTypeRepository catalogTypeRepository, ILogger<CatalogService> logger)
        {
            _catalogItemRepository = catalogItemRepository;
            _catalogTypeRepository = catalogTypeRepository;
            _catalogBrandRepository = catalogBrandRepository;
            _logger = logger;
        }

        public static string RandomType()
        {
            List<string> firstNames = new List<string>();
            firstNames.Add("SNEAKERS");
            firstNames.Add("T-SHIRT");
            firstNames.Add("SWEAT");
            firstNames.Add("JACKET");

            Random randNum = new Random();
            int aRandomPos = randNum.Next(firstNames.Count);

            return firstNames[aRandomPos];
        }

        public static string RandomBrands()
        {
            List<string> firstNames = new List<string>();
            firstNames.Add("NIKE");
            firstNames.Add("ADDIDAS");
            firstNames.Add("PUMA");
            firstNames.Add("ASOS");

            Random randNum = new Random();
            int aRandomPos = randNum.Next(firstNames.Count);

            return firstNames[aRandomPos];
        }

        public override Task<item> CreateCatalogItem(item catalogItem, ServerCallContext context)
        {
            if (catalogItem == null)
            {
                return null;
            }

            var brand = _catalogBrandRepository.FindById(catalogItem.BrandId);
            var newBrand = new Models.Dbo.CBrand
            {
                Brand = "brandName"
            };
           
            var type = _catalogTypeRepository.FindById(catalogItem.TypeId);
            var newType = new Models.Dbo.CType
            {
                Type = "typeName"
            };

            var res = _catalogItemRepository.Insert(new Models.Dbo.CItem
            {
                Id = catalogItem.Id,
                Description = catalogItem.Description,
                Name = catalogItem.Name,
                Price = catalogItem.Price,
                Picturefilename = catalogItem.Picturefilename,
                BrandId = brand == null ? _catalogBrandRepository.Insert(newBrand).Result.Id : brand.Id,
                TypeId = type == null ? _catalogTypeRepository.Insert(newType).Result.Id : type.Id
            });

            return Task.FromResult(new item
            {
                Id = res.Result.Id,
                Description = res.Result.Description,
                Name = res.Result.Name,
                Price = res.Result.Price,
                Picturefilename = res.Result.Picturefilename,
                BrandId = res.Result.BrandId,
                TypeId = res.Result.TypeId
            });
        }


        public override Task<item> GetItemById(itemId id, ServerCallContext context)
        {
            var res = _catalogItemRepository.FindById(id.Id);

            if (res == null)
            {
                return null;
            }

            return Task.FromResult(new item
            {
                Id = res.Id,
                Description = res.Description,
                Name = res.Name,
                Price = res.Price,
                Picturefilename = res.Picturefilename,
                BrandId = res.BrandId,
                TypeId = res.TypeId
            });
        }

        public override Task<deletedResponse> RemoveCatalogItem(itemId id, ServerCallContext context)
        {
            var res = _catalogItemRepository.Delete(id.Id);

            if (res == null)
            {
                return null;
            }

            return Task.FromResult(new deletedResponse
            {
               IsDeleted = res.Result
            });
        }


        public override Task<item> UpdateCatalogItem(item item, ServerCallContext context)
        {

            if (item == null)
            {
                return null;
            }

            var res = _catalogItemRepository.Update(new Models.Dbo.CItem
            { 

                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                Picturefilename = item.Picturefilename,
                BrandId = item.BrandId,
                TypeId = item.TypeId
            });

            return Task.FromResult(new item
            {
                Id = res.Result.Id,
                Description = res.Result.Description,
                Name = res.Result.Name,
                Price = res.Result.Price,
                Picturefilename = res.Result.Picturefilename,
                BrandId = res.Result.BrandId,
                TypeId = res.Result.TypeId
            });
        }
    }
}
