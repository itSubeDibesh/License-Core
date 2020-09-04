using License.LicenseRepo;
using System;

namespace License
{
    class Program
    {
        private static ILicense _license;
        public Program(ILicense license)
        {
            Program._license = license;
        }

        public static void LicenseUseCase()
        {
            var originalColor = Console.ForegroundColor;
            Console.WriteLine("\n|----------------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------      Generate Client, Project Code and License       -----------------|");
            Console.ForegroundColor = originalColor;
            Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
            Console.WriteLine("                        Enter the Values to generate license\n");

            var projectName = "Shahid Bishnu Dhani Memorial Polytechnic Institute";
            Console.WriteLine("   Project Name : {0}", projectName);
            var email = "dibeshrsubedi@gmail.com";
            Console.WriteLine("          Email : {0}", email);
            try
            {
                // Issue Date entry
                Console.Write("    Issued Year : ");
                var issuedYear = int.Parse(Console.ReadLine());
                Console.Write("   Issued Month : ");
                var issuedMonth = int.Parse(Console.ReadLine());
                Console.Write("     Issued Day : ");
                var issuedDay = int.Parse(Console.ReadLine());
                var issued = new DateTime(issuedYear, issuedMonth, issuedDay);
                // Check if issued date is previous than today
                if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")), issued) > 0)
                {
                    Console.Write("    Expiry Year : ");
                    var expiryYear = int.Parse(Console.ReadLine());
                    Console.Write("   Expiry Month : ");
                    var expiryMonth = int.Parse(Console.ReadLine());
                    Console.Write("     Expiry Day : ");
                    var expiryDay = int.Parse(Console.ReadLine());
                    var expiry = new DateTime(expiryYear, expiryMonth, expiryDay);
                    var projectCode = _license.GenerateProjectCode(projectName);
                    var clientCode = _license.GenerateClientCode(email);
                    var certificate = _license.GenerateCertificate(clientCode, projectCode);
                    var generatedLicense = _license.GenerateLicense(clientCode, certificate, issued, expiry);

                    Console.WriteLine("          Input : --------------------------");
                    Console.WriteLine("         Issued : {0}", issued.ToShortDateString());
                    Console.WriteLine("         Expiry : {0}", expiry.ToShortDateString());
                    Console.WriteLine("         Output : --------------------------");
                    Console.WriteLine("   Project Code : {0}", projectCode);
                    Console.WriteLine("    Client Code : {0}", clientCode);
                    Console.WriteLine("    Certificate : {0}", certificate);
                    Console.WriteLine("        License : {0}", generatedLicense);

                    Console.WriteLine("\n|----------------------------------------------------------------------------------------|");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|-----------------              Checking License Validation             -----------------|");
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
                    Console.WriteLine("                        Enter the Values to verify license\n");

                    #region Verification
                    Console.Write("    Certificate : ");
                    var cert = Console.ReadLine();
                    Console.Write("    Client Code : ");
                    var cCode = Console.ReadLine();
                    Console.Write("   Project Code : ");
                    var pCode = Console.ReadLine();
                    var verification = _license.CheckLicenseVerification(generatedLicense, cert, cCode, pCode);
                    if (verification != null)
                    {
                        Console.WriteLine("     Is Expired : {0}", verification.IsExpired);
                        Console.WriteLine("         Expiry : {0}", verification.Expiry);
                        Console.WriteLine("       Is Valid : {0}", verification.IsValid);
                    }
                    else
                    {
                        Console.WriteLine("       Invalid Input or verification failed.");
                    }
                    #endregion
                }
                else
                {
                    Console.WriteLine("\n       Invalid issued date, Entered date should be less than current date.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        static void Main()
        {
            RELOAD:
            _license = new LicenseRepo.License();
            /*
            EncodeDecode encryptDecrypt = new EncodeDecode();
            RandomString random = new RandomString();

            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|  -----------------------      Token, Password & Id Generator     --------------------  |");
            Console.ForegroundColor = OriginalColor;
            Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
            Console.WriteLine("         ID : " + random.RandStringGenerator((int)RandomStringPurpose.ID, 10));
            Console.WriteLine("   PASSWORD : " + random.RandStringGenerator((int)RandomStringPurpose.PASSWORD));
            Console.WriteLine("      TOKEN : " + random.RandStringGenerator((int)RandomStringPurpose.TOKEN));
            Console.WriteLine("    DEFAULT : " + random.RandStringGenerator((int)RandomStringPurpose.DEFAULT));

            Console.WriteLine("\n|----------------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|  -----------------          Password Encrypt and Decrypt         --------------------  |");
            Console.ForegroundColor = OriginalColor;
            Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
            var StringEnc = "Password2020Service";

            Console.WriteLine("   Encrypting Value : " + StringEnc);
            var encrypted = encryptDecrypt.Encrypt(StringEnc);
            Console.WriteLine("\n    Encrypted Value : '" + encrypted + "'");
            var decrypted = encryptDecrypt.Decrypt(encrypted);
            Console.WriteLine("    Decrypted Value : " + decrypted);
            */
            LicenseUseCase();
            CheckReload:
            Console.WriteLine("\n|----------------------------------------------------------------------------------------|\n");
            Console.Write("   Reload (Y/N) : ");
            var input = Console.ReadKey();
            if (input.KeyChar == 'y' || input.KeyChar == 'Y')
            {
                Console.Clear();
                goto RELOAD;
            }
            else if (input.KeyChar == 'n' || input.KeyChar == 'N')
            {
                Console.ReadKey();
                Console.WriteLine("\n|---------------------------      Exiting      ------------------------------------------|\n");
            }
            else
            {
                goto CheckReload;
            }
        }
    }
}
