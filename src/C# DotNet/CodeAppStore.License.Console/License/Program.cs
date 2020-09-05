using CodeAppStore.License.Console.LicenseRepo;
using System;

namespace CodeAppStore.License.Console
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
            var originalColor = System.Console.ForegroundColor;
            System.Console.WriteLine("\n|----------------------------------------------------------------------------------------|");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("|-----------------      Generate Client, Project Code and License       -----------------|");
            System.Console.ForegroundColor = originalColor;
            System.Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
            System.Console.WriteLine("                        Enter the Values to generate license\n");

            var projectName = "Shahid Bishnu Dhani Memorial Polytechnic Institute";
            System.Console.WriteLine("   Project Name : {0}", projectName);
            var email = "dibeshrsubedi@gmail.com";
            System.Console.WriteLine("          Email : {0}", email);
            try
            {
                // Issue Date entry
                System.Console.Write("    Issued Year : ");
                var issuedYear = int.Parse(System.Console.ReadLine());
                System.Console.Write("   Issued Month : ");
                var issuedMonth = int.Parse(System.Console.ReadLine());
                System.Console.Write("     Issued Day : ");
                var issuedDay = int.Parse(System.Console.ReadLine());
                var issued = new DateTime(issuedYear, issuedMonth, issuedDay);
                // Check if issued date is previous than today
                if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")), issued) > 0)
                {
                    System.Console.Write("    Expiry Year : ");
                    var expiryYear = int.Parse(System.Console.ReadLine());
                    System.Console.Write("   Expiry Month : ");
                    var expiryMonth = int.Parse(System.Console.ReadLine());
                    System.Console.Write("     Expiry Day : ");
                    var expiryDay = int.Parse(System.Console.ReadLine());
                    var expiry = new DateTime(expiryYear, expiryMonth, expiryDay);
                    var projectCode = _license.GenerateProjectCode(projectName);
                    var clientCode = _license.GenerateClientCode(email);
                    var certificate = _license.GenerateCertificate(clientCode, projectCode);
                    var generatedLicense = _license.GenerateLicense(clientCode, certificate, issued, expiry);

                    System.Console.WriteLine("          Input : --------------------------");
                    System.Console.WriteLine("         Issued : {0}", issued.ToShortDateString());
                    System.Console.WriteLine("         Expiry : {0}", expiry.ToShortDateString());
                    System.Console.WriteLine("         Output : --------------------------");
                    System.Console.WriteLine("   Project Code : {0}", projectCode);
                    System.Console.WriteLine("    Client Code : {0}", clientCode);
                    System.Console.WriteLine("    Certificate : {0}", certificate);
                    System.Console.WriteLine("        License : {0}", generatedLicense);

                    System.Console.WriteLine("\n|----------------------------------------------------------------------------------------|");
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("|-----------------              Checking License Validation             -----------------|");
                    System.Console.ForegroundColor = originalColor;
                    System.Console.WriteLine("|----------------------------------------------------------------------------------------|\n");
                    System.Console.WriteLine("                        Enter the Values to verify license\n");

                    #region Verification
                    System.Console.Write("    Certificate : ");
                    var cert = System.Console.ReadLine();
                    System.Console.Write("    Client Code : ");
                    var cCode = System.Console.ReadLine();
                    System.Console.Write("   Project Code : ");
                    var pCode = System.Console.ReadLine();
                    var verification = _license.CheckLicenseVerification(generatedLicense, cert, cCode, pCode);
                    if (verification != null)
                    {
                        System.Console.WriteLine("     Is Expired : {0}", verification.IsExpired);
                        System.Console.WriteLine("         Expiry : {0}", verification.Expiry);
                        System.Console.WriteLine("       Is Valid : {0}", verification.IsValid);
                    }
                    else
                    {
                        System.Console.WriteLine("       Invalid Input or verification failed.");
                    }
                    #endregion
                }
                else
                {
                    System.Console.WriteLine("\n       Invalid issued date, Entered date should be less than current date.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
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
            System.Console.WriteLine("\n|----------------------------------------------------------------------------------------|\n");
            System.Console.Write("   Reload (Y/N) : ");
            var input = System.Console.ReadKey();
            if (input.KeyChar == 'y' || input.KeyChar == 'Y')
            {
                System.Console.Clear();
                goto RELOAD;
            }
            else if (input.KeyChar == 'n' || input.KeyChar == 'N')
            {
                System.Console.ReadKey();
                System.Console.WriteLine("\n|---------------------------      Exiting      ------------------------------------------|\n");
            }
            else
            {
                goto CheckReload;
            }
        }
    }
}
