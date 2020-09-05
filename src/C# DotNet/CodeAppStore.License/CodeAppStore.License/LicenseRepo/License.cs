using CodeAppStore.License.RandomStringRepo;
using System;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CodeAppStore.License.LicenseRepo
{
    /// <summary>
    /// License Class used to generate and verify license
    /// </summary>
    public class License : RandomString, ILicense
    {
        #region Variables
        private protected readonly string _EK = ConfigurationManager.ConnectionStrings["_EK"].ConnectionString,
            _EF = ConfigurationManager.ConnectionStrings["_EF"].ConnectionString,
            _ES = ConfigurationManager.ConnectionStrings["_ES"].ConnectionString,
            _CES = ConfigurationManager.ConnectionStrings["_CES"].ConnectionString,
            _PS = ConfigurationManager.ConnectionStrings["_PS"].ConnectionString,
            _CS = ConfigurationManager.ConnectionStrings["_CS"].ConnectionString;
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
            return UpperCase(RndString(12, clientCode + projectCode, 8)).Trim() + projectCode + _PS + projectCode.Length;
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
        /// <code>
        /// If(result == null){"Invalid issued date, Entered issued date should be less than current date."}
        /// </code>
        /// </returns>
        protected string GenerateLicense(string clientCode, string certificate, DateTime issuedDate, DateTime expiryDate)
        {
            if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")), issuedDate) > 0)
            {
                // Convert to short date string and strip back slash
                var id90j = issuedDate.ToString("MM/dd/yyyy").Replace("/", "");
                var ex0up = expiryDate.ToString("MM/dd/yyyy").Replace("/", "");
                // Append Frontier, Issued, GenerateCertificate, Client Code, Encryption Key, Project Code and Expiry
                var lc90xs = _EF + id90j + certificate + clientCode + _EK + ex0up + _CES + id90j.Length + _CS + clientCode.Length;
                // Append Encryption Surfix and Length of License
                lc90xs += _ES + lc90xs.Length;
                // Append Dash on interval of every 6 digits
                var gc0olc = Regex.Replace(lc90xs, ".{6}", "$0-");
                // Get length of newly generated string with dash
                var lc0jol = gc0olc.Length;
                // Check if the lsat digit is dash or not
                if (lc0jol == gc0olc.LastIndexOf("-", StringComparison.Ordinal) + 1)
                {
                    //  Remove the dash and reassign to itself
                    gc0olc = gc0olc.Remove(lc0jol - 1, 1);
                }
                // Return generated string
                return gc0olc;
            }
            else
            {
                return null;
            }
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
            string f01 = license;
            // Stripped Value removing dash
            var sv02 = f01.Replace("-", "");
            // Length of stripped license
            var lsl03 = sv02.Length;
            #endregion
            #region Extract S and value form License Here S = Size of License Excluding value like S52
            // Index of Suffix S which denotes size of string
            var iss04 = sv02.LastIndexOf(Convert.ToChar(_ES));
            // Number of Suffix letters used to denote size of license
            var nsls05 = lsl03 - iss04;
            // Suffix of license including s and value
            var ssr08 = sv02.Substring(iss04, nsls05);
            #endregion
            #region Remove S and value from end
            // Remove S and value from Fetched License
            var sl06 = sv02.Remove(iss04, nsls05);
            // S Removed size of the stripped license
            var sas07 = Convert.ToInt32(ssr08.Replace(_ES, ""));
            // S Removed License Size
            var srs09 = sl06.Length;
            // Return Null if the S Removed Size doesn't match
            if (srs09 != sas07)
                return null;
            #endregion
            #region Extract A and Value and remove it from S-Removed License, Where A = Size of Client code
            // Index of Suffix A which denotes size of string
            var isa10 = sl06.LastIndexOf(Convert.ToChar(_CS));
            // Number of Suffix letters used to denote Client code
            var nsla11 = srs09 - isa10;
            // Suffix of S-Removed License including A and value
            var sal12 = sl06.Substring(isa10, nsla11);
            // Remove A and value from S-Removed License
            var arl13 = sl06.Remove(isa10, nsla11);
            // A Removed size of the stripped license
            var aras14 = Convert.ToInt32(sal12.Replace(_CS, ""));
            // A Removed License Size
            var ars15 = arl13.Length;
            #endregion
            #region Extract C and Value and remove it from A-Removed License, Where C = Certificate
            // Index of Suffix C which denotes size of string
            var isc16 = arl13.LastIndexOf(Convert.ToChar(_CES));
            // Number of Suffix letters used to denote Client code
            var nslc17 = ars15 - isc16;
            // Suffix of A-Removed License including C and value
            var scr18 = arl13.Substring(isc16, nslc17);
            // Remove C and value from A-Removed License
            var crl19 = arl13.Remove(isc16, nslc17);
            // C Removed size of the stripped license
            var crsa20 = Convert.ToInt32(scr18.Replace(_CES, ""));
            #endregion
            #region Extract and Remove Fornteer LICE
            // Index of Prefix E out of LICE
            var ipl21 = Convert.ToInt32(sl06.IndexOf('E')) + 1;
            // Remove LICE from C-Removed License
            var lrl22 = crl19.Remove(0, ipl21);
            // LICE Removed License Size
            var lrs23 = lrl22.Length;
            #endregion
            #region Extract Expiry Date From LICE Removed Licence
            // Index of Prefix R out of LICE-Removed License
            var isr24 = Convert.ToInt32(lrl22.LastIndexOf('R') + 2);
            // Number of Suffix letters used to denote Client code
            var nlr25 = lrs23 - isr24;
            // Extract Value from R till Last Element
            var ed26 = lrl22.Substring(isr24, nlr25);
            // Expiry Removed License
            var erl27 = lrl22.Remove(isr24, nlr25);
            // ExpiryRemoved License Size
            var ers28 = erl27.Length;
            #endregion
            #region Extract and Remove CodeAppStotre from Expiry Removed License
            // Index of Prefix L out of ExpiryRemoved License
            var isl29 = Convert.ToInt32(erl27.LastIndexOf('L'));
            // Number of Suffix letters used to denote Client code
            var nll30 = ers28 - isl29;
            // CODE APP STORE Removed License
            var casrl31 = erl27.Remove(isl29, nll30);
            // CodeAppStore removed Size
            var casrs32 = casrl31.Length;
            #endregion
            #region Remove Client Code
            // Extract Client Code
            var ccs33 = casrl31.Substring(casrs32 - aras14);
            // Remove client Code From String
            var ccrl34 =
                casrl31.Remove((casrs32 - aras14), aras14);
            // ClientCode Removed Size
            var ccrs34 = ccrl34.Length;
            #endregion
            #region Extract Z and Value and remove it from CodeAppStore-Removed License, Where Z = Project Code
            // Index of Suffix Z which denotes size of string
            var isz35 = casrl31.LastIndexOf(Convert.ToChar(_PS));
            // Number of Suffix letters used to denote Project Code code
            var nslz36 = ccrs34 - isz35;
            // Suffix of Z-Removed License including Z and value
            var szr37 = ccrl34.Substring(isz35, nslz36);

            // Remove Z and value from CodeAppStore-Removed License
            var zrl38 = ccrl34.Remove(isz35, nslz36);
            // Z Removed size of the stripped license
            var zrsl39 = Convert.ToInt32(szr37.Replace(_PS, ""));
            #endregion
            #region Separate Certificate and Issued Date
            // Extract Issued Date 
            var id40 = zrl38.Substring(0, crsa20);
            // Remove Certificate From String
            var cs41 =
                zrl38.Remove(0, crsa20);
            //  Certificate String Removed Size
            var csrs42 = cs41.Length;
            #endregion
            #region Extract Project code from  Certificate String
            // Project Code Out Of Certificate string
            var pcs43 = cs41.Substring(csrs42 - zrsl39, zrsl39);
            #endregion
            return new LicenseObject()
            {
                Certificate = cs41 + szr37,
                ProjectCode = pcs43,
                ClientCode = ccs33,
                Expired = DateParser(ed26),
                Issued = DateParser(id40)
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
                DateTimeStyles.None, out var dp01);
            return dp01;
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
            var oj09 = LicenseElements(license);
            var ex09 = oj09.Expired;
            var cd09 = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            if (DateTime.Compare(cd09, ex09) > 0)
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
            var ob909 = LicenseElements(license);
            var cd980 = (Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")));
            var d34a = (cd980 - ob909.Expired).TotalDays;
            d34a = Math.Abs(d34a);
            if (IsExpired(license))
            {
                if (d34a > 1)
                {
                    return "Expired " + d34a + " days ago.";
                }
                else
                {
                    return "Expired " + d34a + " day ago.";
                }
            }
            else
            {
                if (d34a > 0)
                {
                    return "Expires in " + d34a + " days.";
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
            var om90j = LicenseElements(license);
            if (
                string.Compare(om90j.Certificate, certificate, StringComparison.CurrentCulture) == 0 &&
                string.Compare(om90j.ClientCode, clientCode, StringComparison.CurrentCulture) == 0 &&
                string.Compare(om90j.ProjectCode, projectCode, StringComparison.CurrentCulture) == 0
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
            var vf9j0 = IsValid(license, certificate, clientCode, projectCode);
            if (vf9j0)
            {
                var ex9j0 = IsExpired(license);
                var ex09jl = ExpiresIn(license);
                return new LicenseVerificationObject()
                {
                    IsValid = vf9j0,
                    Expiry = ex09jl,
                    IsExpired = ex9j0
                };
            }
            return null;
        }
    }
}