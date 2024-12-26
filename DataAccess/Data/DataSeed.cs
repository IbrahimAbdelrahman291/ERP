using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class DataSeed
    {
        public static async Task SeedAsync(ERPDbContext dbContext) 
        {
            
            if (!dbContext.admins.Any())
            {
                var Admin = new Admin()
                {
                    UserName = "Admin01",
                    Password = "P@ssAdmin"
                };
                await dbContext.Set<Admin>().AddAsync(Admin);
                await dbContext.SaveChangesAsync();

            }
            if (!dbContext.products.Any())
            {
                var ProductsData = File.ReadAllText("../DataAccess/Data/Menu.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (products?.Count > 0)
                {
                    foreach (var product in products)
                    {
                        await dbContext.Set<Product>().AddAsync(product);

                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.Inventory.Any())
            {
                var InventoryData = File.ReadAllText("../DataAccess/Data/Inventory.json");
                var inventories = JsonSerializer.Deserialize<List<Inventory>>(InventoryData);
                if (inventories?.Count > 0)
                {
                    foreach (var inventory in inventories)
                    {
                        await dbContext.Set<Inventory>().AddAsync(inventory);

                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.employees.Any())
            {
                var employee = new Employee()
                {
                    UserName = "Employee",
                    Name = "TempEmp",
                    Password = "P@ssEmployee",
                    AdminId = 1,
                    PhoneNumber = "01200860765"
                };
                await dbContext.Set<Employee>().AddAsync(employee);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
