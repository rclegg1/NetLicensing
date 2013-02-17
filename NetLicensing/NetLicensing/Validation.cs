using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography;

/*
    NetLicensing Library - Key & License Validation Code
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
    public class Validation
    {
        //validateKey
        //Takes a key and validates it against a list of keys
        public bool validateKey(string key, string keys)
        {
            bool rightKey = false;

            if (keys.Contains(key))
            {
                rightKey = true;
            }

            return rightKey;
        }

        public bool validateKeyArray(string key, string[] keys)
        {
            bool rightKey = false;
            int numOfKeys = keys.Count();
            int count = 0;

            while (count < numOfKeys)
            {
                if (keys[count] == key)
                {
                    rightKey = true;
                    break;
                }

                count++;
            }

           

            return rightKey;
        }


        public bool validateLicense(string licenseFile, string key1, string key2, string keys)
        {
            bool validLicense = false;
            try
            {
                StreamReader sr = new StreamReader(licenseFile);

                Networking net = new Networking();
                Encryption enc = new Encryption();

                string licenseInfo = sr.ReadToEnd();
                
                string licenseInfoDecrypted = enc.DecryptString(licenseInfo, key1, key2);
                sr.Close();


                string[] liInfo = licenseInfoDecrypted.Split(' ');

                if (liInfo[0] == net.GetMACAddress().ToString() && validateKey(liInfo[1], keys) == true)
                {
                    
                   validLicense = true;
                }




            }
            catch (Exception)
            {
                ;
            }

            return validLicense;
            

        }

        public bool validateLicenseArray(string licenseFile, string key1, string key2, string[] keys)
        {
            bool validLicense = false;
            try
            {
                StreamReader sr = new StreamReader(licenseFile);

                Networking net = new Networking();
                Encryption enc = new Encryption();

                string licenseInfo = sr.ReadToEnd();

                string licenseInfoDecrypted = enc.DecryptString(licenseInfo, key1, key2);
                sr.Close();


                string[] liInfo = licenseInfoDecrypted.Split(' ');

                if (liInfo[0] == net.GetMACAddress().ToString() && validateKeyArray(liInfo[1], keys) == true)
                {

                    validLicense = true;
                }




            }
            catch (Exception)
            {
                ;
            }

            return validLicense;


        }
          
          
        

            
    }
}
