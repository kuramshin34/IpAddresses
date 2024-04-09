using IpAddresses.Data;

namespace IpAddresses.Commands
{
    public class TimeEnd : ICommand
    {
        public const string command = "--time-end";
        private readonly DataConsoleCommand _data;

        public void Execute(string command)
        {
            DateTime date;
            if (DateTime.TryParse(command, out date))
            {
                _data.TimeEnd = date;
            }
            else
            {
                Console.WriteLine("Такой даты не существует!");
                return;
            }
            _data.IpDates = _data.IpDates.Where(x => x.Date.CurrentDate < _data.TimeEnd).ToList();

        }
        public TimeEnd(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
