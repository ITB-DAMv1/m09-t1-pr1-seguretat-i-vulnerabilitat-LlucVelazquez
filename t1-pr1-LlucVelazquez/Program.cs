using System;
using System.Security.Cryptography;
using System.Text;
namespace t1_pr1_LlucVelazquez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string Msg = "Menu:" +
                "\n1. Registre" +
                "\n2. Verificacio de dades" +
                "\n Encriptacio i desncriptacio amb RSA";

            bool flag = true;
            while (flag)
            {
                Console.WriteLine(Msg);
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        // cosa
                        break;
                    case 2:
                        // otra cosa
                        break;
                    case 3:
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
