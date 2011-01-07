﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibNoDaveConnectionLibrary.DataTypes.Blocks.Step5
{
    public class S5CommentBlock : S5Block
    {        
        public string CommentLines { get; set; }

        public override string ToString()
        {
            return Name + "\r\n" + CommentLines;
        }
    }
}
