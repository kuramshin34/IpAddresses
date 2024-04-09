using IpAddresses.Data;

namespace IpAddresses.Commands
{
    public class TimeStart : ICommand
    {
        public const string command = "--time-start";
        private readonly DataConsoleCommand _data;
        public void Execute(string command)
        {
            DateTime date;
            if (DateTime.TryParse(command, out date))
            {
                _data.TimeStart = date;
            }
            else
            {
                Console.WriteLine("Такой даты не существует!");
                return;
            }
            var newIpDate = _data.IpDates.Where(x => x.Date.CurrentDate > _data.TimeStart).ToList();
            _data.IpDates = newIpDate;

        }
        public TimeStart(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
