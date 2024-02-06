using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHalper
    {
        public static void CreatPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt )
        {//out girilen password ikisinede atıyoruz 
            using (var hmc = new System.Security.Cryptography.HMACSHA512())
            {                                     //bu bizim için bir class üretiyor 
                passwordSalt = hmc.Key;
                passwordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            }//                                    bir stringin byte karşılığı
        }
        
        public static bool VerifyPasswordHash(string password ,byte[] passwordHash,  byte[] passwordSalt )
        {
            using (var hmc = new System.Security.Cryptography.HMACSHA512(passwordSalt))//keyi verdik
            {
                var ComputhedHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));//parolayı tekrardan oluşturuyoruz çünkü salt ile karşılaştıracağız 

                for (int i = 0; i < ComputhedHash.Length; i++)
                {
                    if (ComputhedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;

            }


        }
    }
}
