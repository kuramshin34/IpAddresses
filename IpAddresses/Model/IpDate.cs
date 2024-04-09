using System.Net;

namespace IpAddresses.Model
{
    public class IpDate
    {
        private IPAddress _ip;
        private Date _date;

        public IPAddress Ip => _ip;
        public Date Date => _date;

        public IpDate()
        {
            _ip = IPAddress.Parse("127.0.0.1");
            _date = new Date();
        }
        public IpDate(IPAddress ip)
        {
            _ip = ip;
            _date = new Date();
        }
        public IpDate(Date date)
        {
            _ip = IPAddress.Parse("127.0.0.1");
            _date = date;
        }

        public IpDate(IPAddress ip, Date date)
        {
            _ip = ip;
            _date = date;
        }

        public override string ToString()
        {
            return $"{_ip}:{_date}";
        }
    }
}
