namespace IpAddresses.Model
{
    public class Date
    {
        private DateTime _date;
        public DateTime CurrentDate => _date;


        public override string ToString()
        {
            return _date.ToString();
        }

        public Date()
        {
            _date = DateTime.Now;
        }
        public Date(DateTime date)
        {
            _date = date;
        }
        public Date(string date)
        {
            _date = DateTime.Parse(date);
        }

    }
}
