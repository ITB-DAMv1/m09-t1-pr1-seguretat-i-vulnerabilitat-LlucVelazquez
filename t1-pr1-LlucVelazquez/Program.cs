using System;
using System.Security.Cryptography;
using System.Text;
namespace t1_pr1_LlucVelazquez
{
    public class Program
    {
        static string userHash = null;
        public static void Main(string[] args)
        {
            const string Msg = "Menu:" +
                "\n1. Registre" +
                "\n2. Verificacio de dades" +
                "\n3. Encriptacio i desncriptacio amb RSA";

            bool flag = true;
            while (flag)
            {
                Console.WriteLine(Msg);
                string num = Console.ReadLine();
                switch (num)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        VerifyData();
                        break;
                    case "3":
                        RSAEncryptionDecryption();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
            public static void RSAEncryptionDecryption()
            {
                using (RSA rsa = RSA.Create())
                {
                    // Generar claus pública i privada
                    RSAParameters publicKey = rsa.ExportParameters(false);
                    RSAParameters privateKey = rsa.ExportParameters(true);

                    Console.Write("Introdueix un text per encriptar: ");
                    string inputText = Console.ReadLine();

                    // Encriptació amb clau pública
                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(inputText), RSAEncryptionPadding.Pkcs1);
                    Console.WriteLine($"Text encriptat: {Convert.ToBase64String(encryptedData)}");

                    // Desencriptació amb clau privada
                    byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
                    Console.WriteLine($"Text desencriptat: {Encoding.UTF8.GetString(decryptedData)}");
                }
            }
        public static void Register()
        {
            const string MsgUser = "Introdueix el username: ";
            const string MsgPassword = "Introdueix la password: ";
            Console.WriteLine(MsgUser);
            string username = Console.ReadLine();
            Console.WriteLine(MsgPassword);
            string password = Console.ReadLine();
            string combined = username + password;
            userHash = GetSHA256(combined);
            Console.WriteLine(userHash);
        }
        public static void VerifyData()
        {
            const string MsgUser = "Introdueix el username: ";
            const string MsgPassword = "Introdueix la password: ";
            if (userHash == null)
            {
                Console.WriteLine("No hi ha dades registrades.");
                return;
            }
            Console.WriteLine(MsgUser);
            string username = Console.ReadLine();
            Console.WriteLine(MsgPassword);
            string password = Console.ReadLine();
            string combined = username + password;
            string HashToVerify = GetSHA256(combined);
            if (HashToVerify == userHash)
            {
                Console.WriteLine("Les dades són correctes.");
            }
            else
            {
                Console.WriteLine("Les dades són incorrectes.");
            }
        }
        public static string GetSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
