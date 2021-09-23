using CatalogService;
using Grpc.Net.Client;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var moncul = new CatalogService.Greeter.GreeterClient(channel);

            item i = new item
            {
                Id = 4,
                Description = "update item",
                Name = "First Product",
                Price = 10,
                Picturefilename = "/path/test",
                BrandId = 1,
                TypeId = 1
            };


            var res2 = moncul.UpdateCatalogItem(i);

            Console.WriteLine(res2.Description);
      
        }
    }
}
