using DynamicWebPanel.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynamicWebPanel.Data;

public class DynamicWebPanelDbContext : DbContext
{

    public DbSet<UsersModel> Users { get; set; }

    public DbSet<DepartmentsModel> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ProjectDbString"));
        }

    }

}