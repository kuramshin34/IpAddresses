using IpAddresses.Data;
using IpAddresses.Model;
using System.Net;
using System.Text.RegularExpressions;

namespace IpAddresses.Commands
{
    public class FileLog : ICommand
    {
        Regex regexTxt = new Regex(@"\.txt$");
        Regex regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\b");

        public const string command = "--file-log";
        private readonly DataConsoleCommand _data;
        public void Execute(string command)
        {

            if (regexTxt.IsMatch(command))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(command))
                    {
                        _data.Reset();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (regex.IsMatch(line))
                            {
                                string[] lines = line.Split(':');

                                _data.IpDates.Add(new IpDate(IPAddress.Parse(lines[0]), new Date(string.Concat(lines[1], ":", lines[2], ":", lines[3]))));
                            }
                            else
                                Console.WriteLine("Строка не соответствует формату  -> IP-адрес:yyyy-MM-dd HH:mm:ss <-");

                        }
                    }
                    _data.Add();
                }
                catch
                {
                    Console.WriteLine("Неккоректно указан путь к файлу. Тип файла: .txt");
                }
                return;
            }

            Console.WriteLine("Неккоректно указан путь к файлу. Тип файла: .txt");

        }

        public FileLog(DataConsoleCommand data)
        {
            _data = data;
        }

        
    }
}
