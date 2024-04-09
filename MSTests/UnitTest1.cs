using IpAddresses.Data;
using IpAddresses;
using System.Text.RegularExpressions;
using IpAddresses.Model;
using System.Net;
using IpAddresses.Commands;
using System.Security.Cryptography.X509Certificates;

namespace MSTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CommandIsNull()
        {
            DataConsoleCommand data = new DataConsoleCommand();
            string command = "--file-lo";
            string parameter = "";
            Assert.IsNull(Program.GetCommand(command, parameter)); 
        }

        [TestMethod]
        public void CommandIsNotNull()
        {
            DataConsoleCommand data = new DataConsoleCommand();
            string command = "--file-log";
            string parameter = "";
            Assert.IsNotNull(Program.GetCommand(command, parameter));
            
        }

        [TestMethod]
        public void IsValidCommandTest1()
        {
            Regex regex = new Regex(@"^(--\w+(?:-\w+)*)(?:\s(.+?))?\s*$");
            DataConsoleCommand data = new DataConsoleCommand();
            string parameter = "--file-log";
            Assert.IsTrue(regex.IsMatch(parameter));
        }

        [TestMethod]
        public void IsValidCommandTest2()
        { 
            Regex regex = new Regex(@"^(--\w+(?:-\w+)*)(?:\s(.+?))?\s*$");
            DataConsoleCommand data = new DataConsoleCommand();
            string parameter = "command-go";
            Assert.IsFalse(regex.IsMatch(parameter));
        }
        [TestMethod]
        public void IsValidAddressStart()
        {
            Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            DataConsoleCommand data = new DataConsoleCommand();
            string parameter = "0.0.0.0";
            Assert.IsTrue(regexIP.IsMatch(parameter));
        }
        [TestMethod]
        public void IsValidAddressStart2()
        {
            Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            DataConsoleCommand data = new DataConsoleCommand();
            string parameter = "valid";
            Assert.IsFalse(regexIP.IsMatch(parameter));
        }
        [TestMethod]
        public void IsValidAddressStart3()
        {
            Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            DataConsoleCommand data = new DataConsoleCommand();
            string parameter = "127.0.0";
            Assert.IsFalse(regexIP.IsMatch(parameter));
        }

        [TestMethod]
        public void IsValidTimeStart()
        {
            
            DataConsoleCommand data = new DataConsoleCommand();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {

                data.IpDates.Add(new IpDate(IPAddress.Parse($"{rnd.Next(0, 255)}.{rnd.Next(0, 255)}.{rnd.Next(0, 255)}.{rnd.Next(0, 255)}"), 
                    new Date($"{rnd.Next(1,30)}.{rnd.Next(4,10)}.{rnd.Next(1999, 2019)}")));
            }
            string parameter = "10.10.2022";
            ICommand Command = new TimeStart(data);
            if (Command == null)
            {
                Assert.Fail();
            }
            Command.Execute(parameter);
            Assert.IsTrue(data.IpDates.Count == 0);
        }


    }
}