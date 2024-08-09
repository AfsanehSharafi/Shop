using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    public class DatabaseContextSeed
    {
        public static void CatalogSeed(ModelBuilder modelBuilder)
        {
            foreach (var catalog in GetCatalogTypes())
            {
                modelBuilder.Entity<CatalogType>().HasData(catalog);
            }
            foreach (var brand in GetCatalogBrands())
            {
                modelBuilder.Entity<CatalogBrand>().HasData(brand);
            }
        }


        private static IEnumerable<CatalogType> GetCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() {  Id=0,  Type="کالای دیجیتال"},

                new CatalogType() {  Id= 1,  Type="لوازم جانبی گوشی" , ParetCatalogTypeId = 1},
                new CatalogType() {  Id= 2,  Type="پایه نگهدارنده گوشی" , ParetCatalogTypeId=2},
                new CatalogType() {  Id= 3,  Type="پاور بانک (شارژر همراه)", ParetCatalogTypeId=2},
                new CatalogType() {  Id= 4,  Type="کیف و کاور گوشی", ParetCatalogTypeId=2},



            };
        }

        private static IEnumerable<CatalogBrand> GetCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Id=1, Brand = "سامسونگ" },
                new CatalogBrand() { Id=2, Brand = "شیائومی " },
                new CatalogBrand() { Id=3, Brand = "اپل" },
                new CatalogBrand() { Id=4, Brand = "هوآوی" },
                new CatalogBrand() { Id=5, Brand = "نوکیا " },
                new CatalogBrand() { Id=6, Brand = "ال جی" }
            };
        }
    }
}
