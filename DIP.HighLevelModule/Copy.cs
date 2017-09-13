using Abstractions;
using DIP.MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.HighLevelModule
{
    public class Copy
    {
        private Container _container;
        private IReader _reader;
        private IWriter _writer;
        private IPrinter _printer;

        public Copy(Container container)
        {
            _container = container;
            _reader = _container.Resolve <IReader> ();
            _writer = _container.Resolve <IWriter> ();
            _printer = _container.Resolve<IPrinter>();
        }

        public void DoCopy()
        {
            string stData = _reader.Read();
            _writer.Write(stData);
            _printer.Print(stData);
        }
    }
}
