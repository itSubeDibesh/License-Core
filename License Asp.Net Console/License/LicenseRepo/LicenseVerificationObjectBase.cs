namespace License.LicenseRepo
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
        public bool IsExpired { get; set; }
        public bool IsValid { get; set; }
        public string Expiry { get; set; }
    }
}