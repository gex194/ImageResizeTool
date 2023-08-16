﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeTool
{
    public class Resolution
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
