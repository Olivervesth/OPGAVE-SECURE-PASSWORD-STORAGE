using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace UserLogin
{
    class Hash
    {
        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            Stopwatch monitor = new Stopwatch();
            monitor.Start();
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
            {
                monitor.Stop();
                Console.WriteLine(monitor.ElapsedMilliseconds);
                return rfc2898.GetBytes(32);
            }
        }
    }
}
