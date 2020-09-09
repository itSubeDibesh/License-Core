namespace CodeAppStore.License.LicenseRepo
{
    /// <summary>
    /// License Verification Object Base returned after License is Verified
    /// <list type="LicenseVerificationObjectBase">
    /// IsExpired <see cref="bool"/>,
    /// IsValid <see cref="bool"/>,
    /// Expiry <see cref="string"/>
    /// </list>
    /// </summary>

    public class LicenseVerificationObjectBase
    {
        /// <summary>
        /// Is Expired
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// Is Valid
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Expiry
        /// </summary>
        public string Expiry { get; set; }
    }
}