using IpAddresses.Model;
using System.Net;

namespace IpAddresses.Data
{
    public class DataConsoleCommand
    {
        private string _pathLogger;
        private string _pathResult;

        private IPAddress _addressStart;
        private IPAddress _addressMask;

        private DateTime _timeStart;
        private DateTime _timeEnd;


        private List<IpDate> _ipDates;
        private List<IpDate> defaultIpDate;

        public List<IpDate> IpDates
        {
            get => _ipDates;
            set
            {
                _ipDates = value;
            }
        }
        public List<IpDate> DefaultIpDate => defaultIpDate;

        public string PathLogger
        {
            get => _pathLogger;
            set
            {

                _pathLogger = value;
            }
        }
        public string PathResult
        {
            get => _pathResult;
            set
            {
                _pathResult = value;
            }
        }

        public IPAddress AddressStart
        {
            get => _addressStart;
            set
            {
                _addressStart = value;
                _addressMask = null;
            }
        }
        public IPAddress AddressMask
        {
            get => _addressMask;
            set
            {
                if (_addressStart == null)
                {
                    Console.WriteLine("Нижняя граница диапазона адресов не указана.");
                    return;
                }
                _addressMask = value;

            }
        }
        public DateTime TimeStart
        {
            get => _timeStart;
            set
            {
                if (_timeEnd == DateTime.MaxValue)
                {
                    _timeStart = value;
                    return;
                }
                else if (value >= _timeEnd)
                {
                    Console.WriteLine("Нижняя граница временного интервала не может быть больше Верхней границы временного интервала");
                    return;
                }
                _timeStart = value;
            }
        }

        public DateTime TimeEnd
        {
            get => _timeEnd;
            set
            {
                if (_timeStart == DateTime.MinValue)
                {
                    _timeEnd = value;
                    return;
                }
                else if (value <= _timeStart)
                {
                    Console.WriteLine("Верхняя граница временного интервала не может быть меньше Нижней границы временного интервала");
                    return;
                }
                _timeEnd = value;
            }
        }
        public void Add()
        {
            defaultIpDate.Clear();
            foreach (IpDate ipDate in _ipDates)
            {
                defaultIpDate.Add(ipDate);
            }
        }
        public void Copy()
        {
            _ipDates.Clear();
            foreach (IpDate ipDate in defaultIpDate)
            {
                _ipDates.Add(ipDate);
            }
        }

        public void Reset()
        {
            defaultIpDate.Clear();
            _ipDates.Clear();
            _pathLogger = "";
            _pathResult = "";
            _addressStart = null;
            _addressMask = null;
            _timeStart = DateTime.MinValue;
            _timeEnd = DateTime.MaxValue;
        }

        public DataConsoleCommand()
        {
            _ipDates = new List<IpDate>();
            defaultIpDate = new List<IpDate>();
            _timeStart = DateTime.MinValue;
            _timeEnd = DateTime.MaxValue;
        }
        public DataConsoleCommand(List<IpDate> ipDates)
        {
            _ipDates = ipDates;
            defaultIpDate = new List<IpDate>();
            _timeStart = DateTime.MinValue;
            _timeEnd = DateTime.MaxValue;
        }
    }
}
