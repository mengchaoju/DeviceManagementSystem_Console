using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDevice
{
    public class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=C:\\Users\\50650\\Desktop\\Test\\TestDevice\\TestDevice\\Device.db");
    }

    public class Device
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }
        
    }
}

//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<ApplicationDbContext>(
//        options => options.UseSqlite($"Filename={GlobalConsts.SqliteDbFileName}")
//    );
//}
//设置数据库地址