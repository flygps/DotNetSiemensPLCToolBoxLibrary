﻿/*
 This implements a high level Wrapper between libnodave.dll and applications written
 in MS .Net languages.
 
 This ConnectionLibrary was written by Jochen Kuehner
 * http://jfk-solutuions.de/
 * 
 * Thanks go to:
 * Steffen Krayer -> For his work on MC7 decoding and the Source for his Decoder
 * Zottel         -> For LibNoDave

 LibNoDaveConnectionLibrary is free software; you can redistribute it and/or modify
 it under the terms of the GNU Library General Public License as published by
 the Free Software Foundation; either version 2, or (at your option)
 any later version.

 LibNoDaveConnectionLibrary is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU Library General Public License
 along with Libnodave; see the file COPYING.  If not, write to
 the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.  
*/
using System;
using System.Collections.Generic;
using System.Text;
using LibNoDaveConnectionLibrary.DataTypes.Blocks;

namespace LibNoDaveConnectionLibrary.DataTypes.Blocks
{
    [Serializable()]
    public class PLCFunctionBlock : PLCBlock
    {
        public PLCDataRow Parameter { get; set; }
        public List<PLCFunctionBlockRow> AWLCode { get; set; }

        public string Description{ get; set; }

        //Todo: Implement this
        public void RenameParameter(string oldName, string newName)
        {
        }

        //Todo: Implement this
        public void RenameLabel(string oldName, string newName)
        {
        }

        public override string ToString()
        {
            int bytecnt = 0;
            StringBuilder retVal = new StringBuilder();

            retVal.Append(BlockType.ToString());
            retVal.Append(BlockNumber.ToString());
            retVal.Append(" : ");
            if (Name != null)
                retVal.Append(Name);
            retVal.Append("\r\n\r\n");

            if (Description!=null)
            {
                retVal.Append("Description\r\n\t");
                retVal.Append(Description.Replace("\n", "\r\n\t"));
                retVal.Append("\r\n\r\n");
            }
            if (Parameter != null)
            {
                retVal.Append("Parameter\r\n");
                retVal.Append(Parameter.ToString());
                retVal.Append("\r\n\r\n");
            }

            retVal.Append("AWL-Code\r\n");

            if (AWLCode!=null)
                foreach (var plcFunctionBlockRow in AWLCode)
                {
                    //retVal.Append(/* "0x" + */ bytecnt.ToString(/* "X" */).PadLeft(4, '0') + "  :");
                    retVal.Append(plcFunctionBlockRow.ToString());
                    retVal.Append("\r\n");
                    //bytecnt += plcFunctionBlockRow.ByteSize;
                }
            return retVal.ToString();
        }
    }
}
