using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Implementations
{
    public class PrinterWriter : IWriter
    {
        public void Write(string data)
        {
            Console.WriteLine(string.Format("Writing to \"Printer\": [{0}]", data));
        }
    }
}
