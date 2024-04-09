using IpAddresses.Data;
using IpAddresses.Model;
using System.Text.RegularExpressions;

namespace IpAddresses.Commands
{
    public class FileOutput : ICommand
    {
        Regex regexTxt = new Regex(@"\.txt$");
        public const string command = "--file-output";
        private readonly DataConsoleCommand _data;
        public void Execute(string command)
        {
            if (regexTxt.IsMatch(command))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(command))
                    {
                        foreach (IpDate ipDate in _data.IpDates)
                        {
                            sw.WriteLine(ipDate);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Неправильно указан путь. Тип файла: .txt");
                }
                return;
            }

            Console.WriteLine("Неправильно указан путь. Тип файла: .txt");

        }
        public FileOutput(DataConsoleCommand data)
        {
            _data = data;
        }
    }
}
