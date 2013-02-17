using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
