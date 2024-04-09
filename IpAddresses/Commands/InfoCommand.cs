
namespace IpAddresses.Commands
{
    public class InfoCommand : ICommand
    {
        public const string command = "--info";
        public void Execute(string command)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Команды:");
            Console.WriteLine();
            Console.WriteLine("--file-log - путь к файлу с логами. | Пример: --file-log C:\\data.txt |");
            Console.WriteLine("--file-output - путь к файлу с результатом. | Пример: --file-output C:\\result.txt |");
            Console.WriteLine("--address-start - нижняя грацина диапозона адресов, необязательный параметр," +
                " по умолчанию обрабатываются все запросы | Пример: --address-start 192.168.0.1 и по умолчанию: --address-start |");
            Console.WriteLine("--address-mask - маска подсети, задающая верхнюю границу диапазона десятичное число. " +
                "Необязательный параметр. В случае, если он не указан, обрабатываются все адреса, начиная с нижней границы диапазона. " +
                "Параметр нельзя использовать, если не задан address-start | Пример: --address-mask 255.255.255.0 и по умолчанию: --address-mask |");
            Console.WriteLine("--time-start - нижняя граница временного интервала | Пример: --time-start 10.10.2020 |");
            Console.WriteLine("--time-end - верхняя граница временного интервала | Пример: --time-start 20.10.2024 |");
            Console.WriteLine("--json - возможность частичной/полной передачи параметров | Пример: --json C:\\jsonFile.json или --json C:\\jsonFile.txt|");
            Console.WriteLine("--info - узнать о командах.");
            Console.WriteLine("exit - выход с программы.");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
        }
        public InfoCommand()
        {

        }
    }
}
