namespace CodeAppStore.License.LicenseRepo
{
    /// <summary>
    /// Interface of License
    /// </summary>
    public interface ILicense
    {
        /// <summary>
        /// Generates client code using email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>  Client Code <see cref="string"/> </returns>
        string GenerateClientCode(string email);

        /// <summary>
        ///  Generates project code using project name
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns> Project Code <see cref="string"/>  </returns>
        string GenerateProjectCode(string projectName);

        /// <summary>
        ///  Creates Certificates using ClientCode <see cref="GenerateClientCode"/> and ProductCode <see cref="GenerateProjectCode"/>
        /// </summary>
        /// <param name="clientCode"></param>
        /// <param name="projectCode"></param>
        /// <returns> Certificate <see cref="string"/> </returns>
        string GenerateCertificate(string clientCode, string projectCode);


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
        LicenseVerificationObject CheckLicenseVerification(string license, string certificate,
            string clientCode, string projectCode);
    }
}