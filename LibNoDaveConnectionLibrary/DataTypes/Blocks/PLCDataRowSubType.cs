﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibNoDaveConnectionLibrary.DataTypes.Blocks
{
    public enum PLCDataRowSubType
    {
        IN_VAR = 0x01,
        OUT_VAR = 0x02,
        INOUT_VAR = 0x04,
        STATIC_VAR = 0x04,
        TEMP_VAR = 0x05,
        RETVAL = 0x06,
    }
}
