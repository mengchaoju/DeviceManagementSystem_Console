using System;
using System.Linq;
using Autofac;

namespace TestDevice
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Start running{nameof(Program)}");

            var cb = new ContainerBuilder();
            cb.RegisterType<DeviceRespository>().As<IDeviceRespository>();
            cb.RegisterType<DeviceContext>().As<DeviceContext>();

            var container = cb.Build();
            
            var deviceRespository = container.Resolve<IDeviceRespository>();

            while (true)
            {
                string cmd = Console.ReadLine();
                string[] cmds = cmd.Split(" ");

                switch (cmds[0])
                {
                    case "Create":
                        deviceRespository.CreateDevice(cmds[1]);
                        Console.WriteLine("Finish Insert the Record" + cmds[1]);
                        break;
                    case "QueryByName":
                        System.Collections.Generic.IEnumerable<Device> result = deviceRespository.QueryDeviceByName(cmds[1]);
                        foreach (Device device1 in result)
                        {
                            Console.WriteLine(device1.DeviceID);
                        }
                        break;
                    case "QueryByID":
                        System.Collections.Generic.IEnumerable<Device> resultName = deviceRespository.QueryDeviceByID(int.Parse(cmds[1]));
                        if (resultName.Count() == 0)
                        {
                            Console.WriteLine("No Result!");
                        }
                        else
                        {
                            foreach (Device device1 in resultName)
                            {
                                Console.WriteLine(device1.DeviceID);
                            }
                        }
                        break;
                    case "All":
                        System.Collections.Generic.IEnumerable<Device> all = deviceRespository.GetAll();
                        foreach (Device device1 in all)
                        {
                            Console.WriteLine(device1.DeviceID);
                        }
                        break;
                    case "Update":
                        deviceRespository.UpdateDeviceName(int.Parse(cmds[1]),cmds[2]);
                        break;
                    case "Exit":
                        goto quit;
                    case "Delete":
                        deviceRespository.DeleteDevice(int.Parse(cmds[1]));
                        break;
                    default:
                        Console.WriteLine("Invaild Cmd");
                        break;
                }
            }

            quit:
            Console.WriteLine("Exit");

            //// Create
            //Console.WriteLine("Inserting a new blog");
            //db.Add(new Device { Name = "Device1" });
            //db.SaveChanges();

            //// Read
            //Console.WriteLine("Querying for a blog");
            //var device = db.Devices
            //    .OrderBy(b => b.DeviceID)
            //    .First();

            //// Update
            //Console.WriteLine("Updating the blog and adding a post");
            //device.Name = "Device2";
            //db.SaveChanges();

            //// Delete
            //Console.WriteLine("Delete the blog");
            //db.Remove(device);
            //db.SaveChanges();

        }
    }
}
