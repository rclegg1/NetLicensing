﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    NetLicensing Library - License File Creation Code
    Copyright (C) 2013  Ian Duncan

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

namespace NetLicensing
{
    class License
    {
        public void createLicenseFile(string filename, string key, string key1, string key2)
        {
            Encryption enc = new Encryption();
            Networking net = new Networking();

            StreamWriter sw = new StreamWriter(filename, false);

            sw.Write(enc.EncryptString(net.GetMACAddress() + " " + key, key1, key2));

            sw.Close();
        }

    }
}
