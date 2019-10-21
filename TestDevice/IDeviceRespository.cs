using System;
using System.Collections.Generic;
using System.Text;

namespace TestDevice
{
    public interface IDeviceRespository
    {
        void CreateDevice(string _Name);
        IEnumerable<Device> QueryDeviceByName(string _Name);
        IEnumerable<Device> QueryDeviceByID(int _ID);
        IEnumerable<Device> FilterDevice(string _Name);
        bool UpdateDeviceName(int _ID, string _Name);
        bool DeleteDevice(int _ID);
        IEnumerable<Device> GetAll();
    }
}
