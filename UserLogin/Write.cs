using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Write
    {
        public void SaveUser(string name, string psw,string salt)
        {
            if (!File.Exists(@".\users.txt"))//If file is not existing we create it
            {
                File.Create(@".\users.txt");
            }
            StreamWriter write = new StreamWriter(@".\users.txt",true);//Append true streamwriter lets us write to the file and save the information for later
            write.WriteLine(name + ":" + psw + ":" + salt);
            write.Flush();
            write.Close();
        }

    }
}
