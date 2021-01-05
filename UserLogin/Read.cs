using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Read
    {
        public void ReadUsers(string user, string psw)
        {
            if (!File.Exists(@".\users.txt"))//If file is not existing we create it
            {
                File.Create(@".\users.txt");
            }
            StreamReader read = new StreamReader(@".\users.txt");
            string file = read.ReadToEnd();
            read.Close();
            string[] split = file.Split(':', '\n');
            string username = "";
            string password = "";
            string salt = "";
            int i = 0;
            foreach (var item in split)//Splits the information into strings we can work with
            {
                if (i == 0)
                {
                    username = item.Trim();
                    i++;
                }
                else if (i == 1)
                {
                    password = item.Trim();
                    i++;
                }
                else if (i == 2)
                {
                    i = 0;
                    salt = item.Trim();
                    if (username == user)//Here we are hasing the users login information and compare it with the one we already have to see if the password is correct for the user
                    {
                        byte[] slt = Convert.FromBase64String(salt);
                        var Completecode = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(psw),slt,1000000);
                        string temp = Convert.ToBase64String(Completecode);
                        if (temp == password)
                        {
                            Console.WriteLine($"Logged in as {username}!");
                            Console.ReadKey();
                        }
                    }
                }

            }

        }
    }
}
