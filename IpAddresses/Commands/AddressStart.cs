using IpAddresses.Data;
using IpAddresses.Model;
using System.Net;
using System.Text.RegularExpressions;

namespace IpAddresses.Commands
{
    public class AddressStart : ICommand
    {
        public const string command = "--address-start";
        private readonly DataConsoleCommand _data;
        Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
        public void Execute(string command)
        {
            if (regexIP.IsMatch(command))
            {
                _data.AddressStart = IPAddress.Parse(command);
                byte[] startAddres = _data.AddressStart.GetAddressBytes();
                _data.Copy();
                _data.IpDates = Find(startAddres);
                new TimeStart(_data).Execute(_data.TimeStart.ToString());
                new TimeEnd(_data).Execute(_data.TimeEnd.ToString());
                return;
            }

            Console.WriteLine("Неккоректный IP-адрес нижней границы");
        }

        private List<IpDate> Find(byte[] startAddress)
        {
            List<IpDate> ips = new List<IpDate>();
            foreach (IpDate ip in _data.IpDates)
            {
                bool IsCompare = false;
                byte[] currentByte = ip.Ip.GetAddressBytes();
                for (int i = 0; i < startAddress.Length; i++)
                {
                    if (currentByte[i] > startAddress[i])
                    {
                        IsCompare = true;
                        break;
                    }
                    else if (currentByte[i] < startAddress[i])
                    {
                        break;
                    }
                }
                if (IsCompare == true)
                {
                    ips.Add(ip);
                }
            }
            return ips;
        }

        public AddressStart(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
