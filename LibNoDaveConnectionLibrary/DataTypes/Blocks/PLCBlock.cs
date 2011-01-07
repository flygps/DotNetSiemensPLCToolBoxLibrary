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
using System.Text.RegularExpressions;
using LibNoDaveConnectionLibrary.DataTypes.Blocks;

namespace LibNoDaveConnectionLibrary.DataTypes.Blocks
{
    [Serializable()]
    public class PLCBlock:Block
    {               
        public string BlockVersion;
        public String BlockAttribute;
        public double Length;
        
        public string Author { get; set; }
        public string Family { get; set; }
        public string Version { get; set; }
        public DateTime LastCodeChange { get; set; }
        public DateTime LastInterfaceChange { get; set;}
        public int InterfaceSize { get; set; }
        public int SegmentTableSize { get; set; }
        public int LocalDataSize { get; set; }
        public int CodeSize { get; set; }

        public bool KnowHowProtection { get; set; }

        private byte[] _password;
        public byte[] Password { get
        {
            return _password;
        }
             set
             {
                 _password = new byte[4];
                 if (value.Length >= 1) _password[0] = value[0];
                 if (value.Length >= 2) _password[1] = value[1];
                 if (value.Length >= 3) _password[2] = value[2];
                 if (value.Length >= 4) _password[3] = value[3];
             }
        }        
    }

    

    /*
    [Serializable()]
    public class PLCDataBlockRow
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string StartValue { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return "Name";
        }
    }
    */

    public enum PLCFunctionBlockAdressType
    {
        //Type:
            //0 = Normale Adresse Bsp: T0, E0.1, AW4
            //1 = Indirekte Adresse Bsp: T [DBW4], E [LD3]
            //2 = AR adressierung: T[ar1, p#0.0], DBX [ar1, p#0.0]
            //3 = Nur AR adressierung: [ar1, p#0.0]
        Direct = 0,
        Indirect = 1,
        IndirectWithAR = 2,
        CompleteIndirectWithAR = 3,
        FCParameter = 4
    }

    
}

