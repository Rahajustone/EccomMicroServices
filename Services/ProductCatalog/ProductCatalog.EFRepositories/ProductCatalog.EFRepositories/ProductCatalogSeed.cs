using System;
using ProductCatalog.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductCatalog.EFRepositories
{
	public class ProductCatalogSeed
	{

        public static async Task SeedAsync(ProductCatalogContext context)
        {
            if (!context.CatalogBrands.Any())
            {
                context.CatalogBrands.AddRange(GetPreconfiguredCatalogBrands());
                await context.SaveChangesAsync();
            }
            if (!context.CatalogType.Any())
            {
                context.CatalogType.AddRange(GetPreconfiguredCatalogTypes());
                await context.SaveChangesAsync();
            }
            if (!context.CatalogItem.Any())
            {
                context.CatalogItem.AddRange(GetPreconfiguredItems());
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
                {
                new CatalogBrand() { Brand = "Addidas"},
                new CatalogBrand() { Brand = "Puma" },
                new CatalogBrand() { Brand = "Nike" }
                };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
                return new List<CatalogType>()
                {
                new CatalogType() { Type = "Running"},
                new CatalogType() { Type = "Basketball" },
                new CatalogType() { Type = "Tennis" },
                };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=3, Description = "Shoes for next century", Name = "World Star", Price = 199.5M },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=1,CatalogBrandId=2, Description = "Will make you world champions", Name = "White Line", Price= 88.50M },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=3, Description = "You have already won gold medal", Name = "Prism White Shoes", Price = 129},
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12 },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=2, Description = "Lala Land", Name = "Blue Star", Price = 112},
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=1, Description = "High in the sky", Name = "Roslyn Green", Price = 212},
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=1,CatalogBrandId=1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=1,CatalogBrandId=2, Description = "High Jumper", Name = "Addidas<White> Running", Price = 129 },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=3, Description = "Dunker", Name = "Elequent", Price = 12},
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=1,CatalogBrandId=2, Description = "All round", Name = "Inredeible", Price = 248.5M },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=2,CatalogBrandId=1, Description = "Pricesless", Name = "London Sky", Price = 412 },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=3,CatalogBrandId=3, Description = "Tennis Star", Name = "Elequent", Price = 123 },
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=3,CatalogBrandId=2, Description = "Wimbeldon", Name = "London Star", Price = 218.5M},
                new CatalogItem() {PictureFileName="demo.jpg",CatalogTypeId=3,CatalogBrandId=1, Description = "Rolan Garros", Name = "Paris Blues", Price = 312 }
                };
        }
    }
}

