﻿using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Implementations
{
    public class KeyboardReader : IReader
    {
        public string Read()
        {
            return "Reading from \"Keyboard\"";
        }
    }
}
