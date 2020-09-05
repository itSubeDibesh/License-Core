using CodeAppStore.License.Console.RandomStringRepo;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CodeAppStore.License.Console.LicenseRepo
{
    /// <summary>
    /// License Class used to generate and verify license
    /// </summary>
    [System.Runtime.InteropServices.Guid("5A246B53-C7EF-4508-B2AB-E231BA3C7E79")]
    public class License : RandomString, ILicense
    {
        #region Variables
        private readonly string _encryptionKey = "LC08E9663TOR3";
        private readonly string _encryptionFrontier = "LICE";
        private readonly string _encryptionSuffix = "S";
        private readonly string _certificateSuffix = "C";
        private readonly string _projectSuffix = "Z";
        private readonly string _clientSuffix = "A";
        #endregion

        /// <summary>
        /// Generates client code using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>  Client Code <see cref="string"/> </returns>
        public string GenerateClientCode(string email)
        {
            // Remove everything after @ and convert to uppercase
            email = email.Remove(email.IndexOf('@')).ToUpper();
            // Return random string of minimum 8 - maximum value of 12 and convert to uppercase
            return UpperCase(RndString(12, email.Trim(), 8));
        }

        /// <summary>
        ///  Generates project code using project name
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns> Project Code <see cref="string"/>  </returns>
        public string GenerateProjectCode(string projectName)
        {
            // Replace space and convert to uppercase
            projectName = projectName.ToUpper().Replace(" ", "");
            // Return random string with minimum - 8 and maximum value of 12
            return UpperCase(RndString(12, projectName, 8));
        }

        /// <summary>
        ///  Creates Certificates using ClientCode <see cref="GenerateClientCode"/> and ProductCode <see cref="GenerateProjectCode"/>
        /// </summary>
        /// <param name="clientCode"></param>
        /// <param name="projectCode"></param>
        /// <returns> Certificate <see cref="string"/> </returns>
        public string GenerateCertificate(string clientCode, string projectCode)
        {
            // Convert to capital cased random string with concatenated value of client code and project with appended project code
            return UpperCase(RndString(12, clientCode + projectCode, 8)).Trim() + projectCode + _projectSuffix + projectCode.Length;
        }

        /// <summary>
        ///    Generates license using parameters
        /// </summary>
        /// <param name="clientCode"></param>
        /// <param name="certificate"></param>
        /// <param name="issuedDate"></param>
        /// <param name="expiryDate"></param>
        /// <returns>
        /// License <see cref="string"/>
        /// </returns>
        public string GenerateLicense(string clientCode, string certificate, DateTime issuedDate, DateTime expiryDate)
        {
            // Convert to short date string and strip back slash
            var issued = issuedDate.ToString("MM/dd/yyyy").Replace("/", "");
            var expiry = expiryDate.ToString("MM/dd/yyyy").Replace("/", "");
            // Append Frontier, Issued, GenerateCertificate, Client Code, Encryption Key, Project Code and Expiry
            var license = _encryptionFrontier + issued + certificate + clientCode + _encryptionKey + expiry + _certificateSuffix + issued.Length + _clientSuffix + clientCode.Length;
            // Append Encryption Surfix and Length of License
            license += _encryptionSuffix + license.Length;
            // Append Dash on interval of every 6 digits
            var generated = Regex.Replace(license, ".{6}", "$0-");
            // Get length of newly generated string with dash
            var length = generated.Length;
            // Check if the lsat digit is dash or not
            if (length == generated.LastIndexOf("-", StringComparison.Ordinal) + 1)
            {
                //  Remove the dash and reassign to itself
                generated = generated.Remove(length - 1, 1);
            }
            // Return generated string
            return generated;
        }

        /// <summary>
        /// Returns License Elements by decoding the License
        /// </summary>
        /// <param name="license"></param>
        /// <returns>
        /// License Object <see cref="LicenseObject"/>
        /// </returns>
        protected LicenseObject LicenseElements(string license)
        {
            #region Fetched License
            // Return null if the license is null
            if (string.IsNullOrWhiteSpace(license))
                return null;
            // Fetched License Key 
            string fetchedLicense = license;
            // Stripped Value removing dash
            var stripedLicense = fetchedLicense.Replace("-", "");
            // Length of stripped license
            var lengthOfStripedLicense = stripedLicense.Length;
            #endregion
            #region Extract S and value form License Here S = Size of License Excluding value like S52
            // Index of Suffix S which denotes size of string
            var indexOfSuffixS = stripedLicense.LastIndexOf('S');
            // Number of Suffix letters used to denote size of license
            var numberOfSuffixLetterS = lengthOfStripedLicense - indexOfSuffixS;
            // Suffix of license including s and value
            var suffixSRemoved = stripedLicense.Substring(indexOfSuffixS, numberOfSuffixLetterS);
            #endregion
            #region Remove S and value from end
            // Remove S and value from Fetched License
            var sRemovedLicense = stripedLicense.Remove(indexOfSuffixS, numberOfSuffixLetterS);
            // S Removed size of the stripped license
            var sRemovedActualSize = Convert.ToInt32(suffixSRemoved.Replace("S", ""));
            // S Removed License Size
            var sRemovedSize = sRemovedLicense.Length;
            // Return Null if the S Removed Size doesn't match
            if (sRemovedSize != sRemovedActualSize)
                return null;
            #endregion
            #region Extract A and Value and remove it from S-Removed License, Where A = Size of Client code
            // Index of Suffix A which denotes size of string
            var indexOfSuffixA = sRemovedLicense.LastIndexOf('A');
            // Number of Suffix letters used to denote Client code
            var numberOfSuffixLetterA = sRemovedSize - indexOfSuffixA;
            // Suffix of S-Removed License including A and value
            var suffixARemoved = sRemovedLicense.Substring(indexOfSuffixA, numberOfSuffixLetterA);
            // Remove A and value from S-Removed License
            var aRemovedLicense = sRemovedLicense.Remove(indexOfSuffixA, numberOfSuffixLetterA);
            // A Removed size of the stripped license
            var aRemovedActualSize = Convert.ToInt32(suffixARemoved.Replace("A", ""));
            // A Removed License Size
            var aRemovedSize = aRemovedLicense.Length;
            #endregion
            #region Extract C and Value and remove it from A-Removed License, Where C = Certificate
            // Index of Suffix C which denotes size of string
            var indexOfSuffixC = aRemovedLicense.LastIndexOf('C');
            // Number of Suffix letters used to denote Client code
            var numberOfSuffixLetterC = aRemovedSize - indexOfSuffixC;
            // Suffix of A-Removed License including C and value
            var suffixCRemoved = aRemovedLicense.Substring(indexOfSuffixC, numberOfSuffixLetterC);
            // Remove C and value from A-Removed License
            var cRemovedLicense = aRemovedLicense.Remove(indexOfSuffixC, numberOfSuffixLetterC);
            // C Removed size of the stripped license
            var cRemovedActualSize = Convert.ToInt32(suffixCRemoved.Replace("C", ""));
            #endregion
            #region Extract and Remove Fornteer LICE
            // Index of Prefix E out of LICE
            var indexOfPrefixLice = Convert.ToInt32(sRemovedLicense.IndexOf('E')) + 1;
            // Remove LICE from C-Removed License
            var liceRemovedLicense = cRemovedLicense.Remove(0, indexOfPrefixLice);
            // LICE Removed License Size
            var liceRemovedSize = liceRemovedLicense.Length;
            #endregion
            #region Extract Expiry Date From LICE Removed Licence
            // Index of Prefix R out of LICE-Removed License
            var indexOfSuffixR = Convert.ToInt32(liceRemovedLicense.LastIndexOf('R') + 2);
            // Number of Suffix letters used to denote Client code
            var numberOfLetterFromR = liceRemovedSize - indexOfSuffixR;
            // Extract Value from R till Last Element
            var expiryDate = liceRemovedLicense.Substring(indexOfSuffixR, numberOfLetterFromR);
            // Expiry Removed License
            var expiryRemovedLicense = liceRemovedLicense.Remove(indexOfSuffixR, numberOfLetterFromR);
            // ExpiryRemoved License Size
            var expiryRemovedSize = expiryRemovedLicense.Length;
            #endregion
            #region Extract and Remove CodeAppStotre from Expiry Removed License
            // Index of Prefix L out of ExpiryRemoved License
            var indexOfSuffixL = Convert.ToInt32(expiryRemovedLicense.LastIndexOf('L'));
            // Number of Suffix letters used to denote Client code
            var numberOfLetterFromL = expiryRemovedSize - indexOfSuffixL;
            // CODE APP STORE Removed License
            var codeAppStoreRemovedLicense = expiryRemovedLicense.Remove(indexOfSuffixL, numberOfLetterFromL);
            // CodeAppStore removed Size
            var codeAppStoreRemovedSize = codeAppStoreRemovedLicense.Length;
            #endregion
            #region Remove Client Code
            // Extract Client Code
            var clientCodeString = codeAppStoreRemovedLicense.Substring(codeAppStoreRemovedSize - aRemovedActualSize);
            // Remove client Code From String
            var clientCodeRemovedLicense =
                codeAppStoreRemovedLicense.Remove((codeAppStoreRemovedSize - aRemovedActualSize), aRemovedActualSize);
            // ClientCode Removed Size
            var clientCodeRemovedSize = clientCodeRemovedLicense.Length;
            #endregion
            #region Extract Z and Value and remove it from CodeAppStore-Removed License, Where Z = Project Code
            // Index of Suffix Z which denotes size of string
            var indexOfSuffixZ = codeAppStoreRemovedLicense.LastIndexOf('Z');
            // Number of Suffix letters used to denote Project Code code
            var numberOfSuffixLetterZ = clientCodeRemovedSize - indexOfSuffixZ;
            // Suffix of Z-Removed License including Z and value
            var suffixZRemoved = clientCodeRemovedLicense.Substring(indexOfSuffixZ, numberOfSuffixLetterZ);

            // Remove Z and value from CodeAppStore-Removed License
            var zRemovedLicense = clientCodeRemovedLicense.Remove(indexOfSuffixZ, numberOfSuffixLetterZ);
            // Z Removed size of the stripped license
            var zRemovedActualSize = Convert.ToInt32(suffixZRemoved.Replace("Z", ""));
            #endregion
            #region Separate Certificate and Issued Date
            // Extract Issued Date 
            var issuedDate = zRemovedLicense.Substring(0, cRemovedActualSize);
            // Remove Certificate From String
            var certificateString =
                zRemovedLicense.Remove(0, cRemovedActualSize);
            //  Certificate String Removed Size
            var certificateStringRemovedSize = certificateString.Length;
            #endregion
            #region Extract Project code from  Certificate String
            // Project Code Out Of Certificate string
            var projectCodeString = certificateString.Substring(certificateStringRemovedSize - zRemovedActualSize, zRemovedActualSize);
            #endregion
            #region Acepted console 
            /*
            Console.WriteLine("StripedLicense: " + StripedLicense);
            Console.WriteLine("LengthOfStripedLicense: " + LengthOfStripedLicense);

            Console.WriteLine("\nNumberOfSuffixLetterS: " + NumberOfSuffixLetterS);
            Console.WriteLine("SRemovedActualSize: " + SRemovedActualSize);
            Console.WriteLine("SuffixSRemoved: " + SuffixSRemoved);
            Console.WriteLine("SRemovedLicense: " + SRemovedLicense);

            Console.WriteLine("\nSRemovedSize: " + SRemovedSize);
            Console.WriteLine("NumberOfSuffixLetterA: " + NumberOfSuffixLetterA);
            Console.WriteLine("SuffixARemoved: " + SuffixARemoved);
            Console.WriteLine("ARemovedLicense: " + ARemovedLicense);

            Console.WriteLine("\nARemovedSize: " + ARemovedSize);
            Console.WriteLine("NumberOfSuffixLetterC: " + NumberOfSuffixLetterC);
            Console.WriteLine("SuffixCRemoved: " + SuffixCRemoved);
            Console.WriteLine("CRemovedLicense: " + CRemovedLicense);

            Console.WriteLine("\nCRemovedSize: " + CRemovedSize);
            Console.WriteLine("IndexOfPrefixLICE: " + IndexOfPrefixLICE);
            Console.WriteLine("PrefixLICERemoved: " + PrefixLICERemoved);
            Console.WriteLine("LICERemovedLicense: " + LICERemovedLicense);

            Console.WriteLine("\nLICERemovedSize: " + LICERemovedSize);
            Console.WriteLine("IndexOfSuffixR: " + IndexOfSuffixR);
            Console.WriteLine("ExpiryDate: " + ExpiryDate);
            Console.WriteLine("ExpiryRemovedLicense: " + ExpiryRemovedLicense);

            Console.WriteLine("\nExpiryRemovedSize: " + ExpiryRemovedSize);
            Console.WriteLine("IndexOfSuffixL: " + IndexOfSuffixL);
            Console.WriteLine("CodeAppStore: " + CodeAppStore);
            Console.WriteLine("CodeAppStoreRemovedLicense: " + CodeAppStoreRemovedLicense);

            Console.WriteLine("\nCodeAppStoreRemovedSize: " + CodeAppStoreRemovedSize);
            Console.WriteLine("ARemovedActualSize: " + ARemovedActualSize);
            Console.WriteLine("ClientCodeString: " + ClientCodeString);
            Console.WriteLine("ClientCodeRemovedLicense: " + ClientCodeRemovedLicense);

            Console.WriteLine("\nClientCodeRemovedSize: " + ClientCodeRemovedSize);
            Console.WriteLine("IndexOfSuffixZ: " + IndexOfSuffixZ);
            Console.WriteLine("SuffixZRemoved: " + SuffixZRemoved);
            Console.WriteLine("ZRemovedLicense: " + ZRemovedLicense);

            Console.WriteLine("\nZRemovedSize: " + ZRemovedSize);
            Console.WriteLine("CRemovedActualSize: " + CRemovedActualSize);
            Console.WriteLine("IssuedDate: " + IssuedDate);
            Console.WriteLine("CertificateString: " + CertificateString + SuffixZRemoved);
            Console.WriteLine("ProjectCodeString: " + ProjectCodeString);
            */
            #endregion

            return new LicenseObject()
            {
                Certificate = certificateString + suffixZRemoved,
                ProjectCode = projectCodeString,
                ClientCode = clientCodeString,
                Expired = DateParser(expiryDate),
                Issued = DateParser(issuedDate)
            };
        }

        /// <summary>
        /// Receives dates in MMddYYYY format and returns MM/DD/YYYY
        /// </summary>
        /// <param name="date"></param>
        /// <returns>MM/DD/YYYY <see cref="DateTime"/> </returns>
        private DateTime DateParser(string date)
        {
            DateTime.TryParseExact(date, "MMddyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var dateParsed);
            return dateParsed;
        }

        /// <summary>
        /// Checks if the input license has expired
        /// </summary>
        /// <param name="license"></param>
        /// <returns> True || False <see cref="bool"/> </returns>
        private bool IsExpired(string license)
        {
            if (string.IsNullOrWhiteSpace(license))
                return false;
            var obj = LicenseElements(license);
            var expiry = obj.Expired;
            var currentDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            if (DateTime.Compare(currentDate, expiry) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Fetch Dates from License and check if license is expired and calculate days to expiry
        /// </summary>
        /// <param name="license"></param>
        /// <returns> Expires in x days  <see cref="string"/> </returns>
        private string ExpiresIn(string license)
        {
            if (string.IsNullOrWhiteSpace(license))
                return null;
            var obj = LicenseElements(license);
            var current = (Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")));
            var days = (current - obj.Expired).TotalDays;
            days = Math.Abs(days);
            if (IsExpired(license))
            {
                if (days > 1)
                {
                    return "Expired " + days + " days ago.";
                }
                else
                {
                    return "Expired " + days + " day ago.";
                }
            }
            else
            {
                if (days > 0)
                {
                    return "Expires in " + days + " days.";
                }
                else
                {
                    return "Expires today.";
                }
            }
        }

        /// <summary>
        ///     Checks if The Decoded License Variables and Input Variables match or not
        /// </summary>
        /// <param name="license"></param>
        /// <param name="certificate"></param>
        /// <param name="clientCode"></param>
        /// <param name="projectCode"></param>
        /// <returns> True || False <see cref="bool"/> </returns>
        private bool IsValid(string license, string certificate, string clientCode, string projectCode)
        {
            if (
                string.IsNullOrWhiteSpace(license) &&
                string.IsNullOrWhiteSpace(certificate) &&
                string.IsNullOrWhiteSpace(clientCode) &&
                string.IsNullOrWhiteSpace(projectCode)
                )
                return false;
            var obj = LicenseElements(license);
            if (
                string.Compare(obj.Certificate, certificate, StringComparison.CurrentCulture) == 0 &&
                string.Compare(obj.ClientCode, clientCode, StringComparison.CurrentCulture) == 0 &&
                string.Compare(obj.ProjectCode, projectCode, StringComparison.CurrentCulture) == 0
                )
                return true;
            else
                return false;

        }

        /// <summary>
        /// Validates the input
        /// Certificate [<see cref="GenerateCertificate"/>],
        /// ClientCode [<see cref="GenerateClientCode"/>] and
        /// ProjectCode [<see cref="GenerateProjectCode"/>]
        /// using <see cref="IsValid"/>
        /// using <see cref="ExpiresIn"/> and 
        /// using <see cref="IsExpired"/>.
        /// </summary>
        /// <param name="license"></param>
        /// <param name="certificate"></param>
        /// <param name="clientCode"></param>
        /// <param name="projectCode"></param>
        /// <returns>
        /// License Verification Object <see cref="LicenseVerificationObject"/>
        /// </returns>
        public LicenseVerificationObject CheckLicenseVerification(string license, string certificate,
            string clientCode, string projectCode)
        {
            var verified = IsValid(license, certificate, clientCode, projectCode);
            if (verified)
            {
                var expired = IsExpired(license);
                var expiry = ExpiresIn(license);
                return new LicenseVerificationObject()
                {
                    IsValid = verified,
                    Expiry = expiry,
                    IsExpired = expired
                };
            }
            return null;
        }
    }
}