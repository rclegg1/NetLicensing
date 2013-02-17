using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography;

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
          
        

            
    }
}
