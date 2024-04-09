using IpAddresses.Data;

namespace IpAddresses.Commands
{
    public class AddressStartDefault : ICommand
    {

        public const string command = "--address-start";
        private readonly DataConsoleCommand _data;
        public void Execute(string command)
        {
            _data.AddressStart = null;
            _data.Copy();
            new TimeStart(_data).Execute(_data.TimeStart.ToString());
            new TimeEnd(_data).Execute(_data.TimeEnd.ToString());
        }


        public AddressStartDefault(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
