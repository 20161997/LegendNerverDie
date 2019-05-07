namespace LND.Data.Migrations
{
    using LND.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LND.Data.LegendNeverDieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LND.Data.LegendNeverDieDbContext context)
        {
            ////  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new LegendNeverDieDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new LegendNeverDieDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "hung",
            //    Email = "hung.vv161997@sis.hust.edu.vn",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Hung Vu Van"

            //};

            //manager.Create(user, "a12345678");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("hung.vv161997@sis.hust.edu.vn");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            CreateProductCategorySample(context);

        }
        private void CreateProductCategorySample(LND.Data.LegendNeverDieDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}
