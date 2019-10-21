using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDevice
{
    public class DeviceRespository: IDeviceRespository
    {
        private readonly DeviceContext deviceContext;
        public DeviceRespository(DeviceContext _deviceContext)
        {
            deviceContext = _deviceContext;
        }
         
        public void CreateDevice(string _Name)
        {
            Console.WriteLine("Inserting a new device");
            deviceContext.Add(new Device { Name = _Name });
            deviceContext.SaveChanges();
        }

        public IEnumerable<Device> QueryDeviceByName(string _Name)
        {
            Console.WriteLine("Querying for a device by Name");
            var device = deviceContext.Devices.Where(b => b.Name == _Name);
            if (device == null)
            {
                return null;
            }
            else
            {
                return device;
            }
        }

        public IEnumerable<Device> QueryDeviceByID(int _ID)
        {
            Console.WriteLine("Querying for a device by ID");
            var device = deviceContext.Devices.Where(y=>y.DeviceID.Equals(_ID));
            if (device == null)
            {
                return null;
            }
            else
            {
                return device;
            }

        }

        public IEnumerable<Device> FilterDevice(string _Name)
        {
            Console.WriteLine("Querying for a device by Name");
            var devices = deviceContext.Devices.Where(b => b.Name.Contains(_Name))
                .ToList();
            return devices;
        }

        public bool UpdateDeviceName(int _ID, string _Name)
        {
            Console.WriteLine("Updating the device name");
            var device = deviceContext.Devices.Where(b => b.DeviceID.Equals(_ID));
            if (device == null)
            {
                return false;
            }
            else
            {
                foreach(Device device1 in device)
                {
                    device1.Name = _Name;
                }
                return true;
            }
        }

        public IEnumerable<Device> GetAll()
        {
            Console.WriteLine("Get All Records");
            var devie = deviceContext.Devices.ToList();
            return devie;
        }

        public bool DeleteDevice(int _ID)
        {
            Console.WriteLine("Delete the device");
            var device = deviceContext.Devices.Where(b => b.DeviceID.Equals(_ID));
            if (device == null)
            {
                return false;
            }
            else
            {
                foreach(Device dev in device)
                {
                    deviceContext.Remove(dev);
                }
                return true;
            }

        }
    }
}

//static public void AddSharpMemberCore(this IServiceCollection services, IConfiguration Configuration)
//{
//    bool config_UnitTestConnectionEnabled = Configuration.GetValue<bool>("UnitTestConnectionEnabled");
//    switch (GlobalConfigs.DatabaseType)
//    {
//        case eDatabaseType.Sqlite:
//            services.AddDbContext<ApplicationDbContext>(
//                options => options.UseSqlite($"Filename={DbConsts.SqliteDbFileName}")
//            );
//            break;
//        case eDatabaseType.SqlServer:
//            string connectionStringConfig = "DefaultConnection";
//            if (config_UnitTestConnectionEnabled)
//                connectionStringConfig = "UnitTestConnection";

//            services.AddDbContext<ApplicationDbContext>(options =>
//               options.UseSqlServer(
//                   Configuration.GetConnectionString(connectionStringConfig),
//                   sqlServerOption => sqlServerOption.MigrationsAssembly("SharpMember.Migrations.SqlServer")
//               ));
//            break;
//        case eDatabaseType.Postgres:
//            string postgresConnStr = "PostgresConnection";
//            if (config_UnitTestConnectionEnabled)
//                postgresConnStr = "PostgresConnection_UnitTest";

//            services.AddDbContext<ApplicationDbContext>(options =>
//               options.UseNpgsql(
//                   Configuration.GetConnectionString(postgresConnStr),
//                   postgresOption => postgresOption.MigrationsAssembly("SharpMember.Migrations.Postgres")
//               ));
//            break;
//        default:
//            throw new Exception("Unknown database type for DbContext dependency injection");
//    }