using System;
using System.Linq;
using TestDevice;
using Xunit;

namespace UnitTestDevice
{
    public class Test
    {
        DeviceContext db = new DeviceContext();
      
        IDeviceRespository dbTest = new DeviceRespository(new DeviceContext());
        [Fact]
        public void CreateTest()
        {
            //Arrange
            string name = "Device1";
            //Act
            int oldNum = db.Devices.Count();
            dbTest.CreateDevice(name);
            int newNum = db.Devices.Count();
            //Assert
            Xunit.Assert.Equal(1, newNum-oldNum);
        }

        [Fact]
        public void QueryByNameTest()
        {
            //Arrange
            string name = "Device1";
            //Act
            var result = dbTest.QueryDeviceByName(name);
            //Assert
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public void QueryByIDTest()
        {
            //Arrange
            int id = 1;
            //Act
            var result = dbTest.QueryDeviceByID(id);
            //Assert
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public void UpdateTest()
        {
            string newName = "Device2";
            int id = 1;
            bool result = dbTest.UpdateDeviceName(id, newName);
            string _newName = dbTest.QueryDeviceByID(1).First().Name;
            Xunit.Assert.Equal("Device2", _newName);
        }

        [Fact]
        public void DeleteTest()
        {
            int id = 1;
            bool result = dbTest.DeleteDevice(id);
            Xunit.Assert.True(result);
        }
    }
}
