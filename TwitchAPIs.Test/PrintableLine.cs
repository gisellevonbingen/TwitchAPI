﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class PrintableLine
    {
        public int Level { get; set; }
        public string Message { get; set; }

        public PrintableLine()
        {

        }

        public PrintableLine(int level, string message)
        {
            this.Level = level;
            this.Message = message;
        }

    }

}
