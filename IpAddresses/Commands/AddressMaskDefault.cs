using IpAddresses.Data;

namespace IpAddresses.Commands
{
    public class AddressMaskDefault : ICommand
    {
        public const string command = "--address-mask";
        private readonly DataConsoleCommand _data;

        public void Execute(string command)
        {
            _data.Copy();
            new AddressStart(_data).Execute(_data.AddressStart.ToString());
            new TimeStart(_data).Execute(_data.TimeStart.ToString());
            new TimeEnd(_data).Execute(_data.TimeEnd.ToString());

        }

        public AddressMaskDefault(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
