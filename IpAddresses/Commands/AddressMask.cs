using IpAddresses.Data;
using IpAddresses.Model;
using System.Net;
using System.Text.RegularExpressions;

namespace IpAddresses.Commands
{
    public class AddressMask : ICommand
    {
        public const string command = "--address-mask";
        private readonly DataConsoleCommand _data;
        Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");

        public void Execute(string command)
        {
            if (regexIP.IsMatch(command))
            {
                _data.AddressMask = IPAddress.Parse(command);

                byte[] startBytes = _data.AddressStart.GetAddressBytes();
                byte[] maskBytes = _data.AddressMask.GetAddressBytes();

                IPAddress endAddress = null;
                if (startBytes.Length == maskBytes.Length)
                {
                    endAddress = GetEndAddress(startBytes, maskBytes);
                    _data.AddressMask = endAddress;
                    maskBytes = endAddress.GetAddressBytes();
                    _data.Copy();
                    _data.IpDates = Find(startBytes, maskBytes);
                    new TimeStart(_data).Execute(_data.TimeStart.ToString());
                    new TimeEnd(_data).Execute(_data.TimeEnd.ToString());
                }
                else
                {
                    Console.WriteLine("Нижняя граница диапазона адресов и маска подсети представлены в разном формате");
                    return;
                }
                return;
            }
            else if (command == "" || command == null)
            {

            }
            Console.WriteLine("Неккоректный IP-адрес маски подсети");
        }

        private List<IpDate> Find(byte[] startBytes, byte[] maskBytes)
        {
            List<IpDate> ips = new List<IpDate>();
            foreach (IpDate ip in _data.IpDates)
            {
                bool IsCompare = false;
                byte[] currentByte = ip.Ip.GetAddressBytes();
                for (int i = 0; i < maskBytes.Length; i++)
                {
                    if (currentByte[i] > startBytes[i] && currentByte[i] < maskBytes[i])
                    {
                        IsCompare = true;
                        break;
                    }
                    else if (currentByte[i] < startBytes[i] || currentByte[i] > maskBytes[i])
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

        private IPAddress GetEndAddress(byte[] startAddressBytes, byte[] maskBytes)
        {
            byte[] endAddressBytes = new byte[startAddressBytes.Length];

            for (int i = 0; i < startAddressBytes.Length; i++)
            {
                endAddressBytes[i] = (byte)(startAddressBytes[i] | ~maskBytes[i]);
            }

            return new IPAddress(endAddressBytes);
        }

        public AddressMask(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
