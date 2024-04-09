using IpAddresses.Commands;
using IpAddresses.Data;
using IpAddresses.JsonClasses;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace IpAddresses
{
    public class Program
    {

        
        private static DataConsoleCommand _data;
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^(--\w+(?:-\w+)*)(?:\s(.+?))?\s*$");
            _data = new DataConsoleCommand();

            Console.WriteLine("Приветствую вас, вводите команду");
            while (true)
            {
                string command = Console.ReadLine();
                if (regex.IsMatch(command))
                {
                    string[] commands = command.Split(' ');
                    if (commands.Length == 1)
                    {
                        commands = new string[2] { command, "" };
                    }
                    ICommand Command = GetCommand(commands[0], commands[1]);
                    if (Command == null) 
                    {
                        Console.WriteLine("Некорректная команда");
                        continue;
                    }
                    Command.Execute(commands[1]);
                }
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректная команда");
                }
            }
            Console.WriteLine("Хорошо провести время");

        }

        public static ICommand GetCommand(string command, string param)
        {
            if (FileLog.command == command)
            {
                return new FileLog(_data);
            }
            else if (FileOutput.command == command)
            {
                return new FileOutput(_data);
            }
            else if (AddressStartDefault.command == command && param == "")
            {
                return new AddressStartDefault(_data);
            }
            else if (AddressMaskDefault.command == command && param == "")
            {
                return new AddressMaskDefault(_data);
            }
            else if (AddressStart.command == command)
            {
                return new AddressStart(_data);
            }
            else if (AddressMask.command == command)
            {
                return new AddressMask(_data);
            }
            else if (TimeStart.command == command)
            {
                return new TimeStart(_data);
            }
            else if (TimeEnd.command == command)
            {
                return new TimeEnd(_data);
            }
            else if (JsonCommand.command == command)
            {
                return new JsonCommand();
            }
            else if (InfoCommand.command == command && param == "")
            {
                return new InfoCommand();
            }
           
            return null;
        }

        public class JsonCommand : ICommand
        {
            public const string command = "--json";

            public void Execute(string command)
            {
                try
                {
                    string json = File.ReadAllText(command);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var data = JsonSerializer.Deserialize<ListJson>(json, options);

                    foreach (var item in data.ipDate)
                    {
                        ICommand CommandJson = GetCommand(item.Command, item.Parameter);
                        CommandJson.Execute(item.Parameter);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"JSON не соответствует.");
                }
            }
            public JsonCommand()
            {

            }
        }


    }
    
}
