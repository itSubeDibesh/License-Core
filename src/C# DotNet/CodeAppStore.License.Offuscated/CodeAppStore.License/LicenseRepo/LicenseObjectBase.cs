using System;

namespace CodeAppStore.License.LicenseRepo
{
    /// <summary>
    /// License Object Base returned after License details is decoded
    /// <list type="LicenseObjectBase">
    /// ClientCode <see cref="string"/>,
    /// ProjectCode <see cref="string"/>,
    /// Certificate <see cref="string"/>,
    /// Issued <see cref="DateTime"/>,
    /// Expired <see cref="DateTime"/>
    /// </list>
    /// </summary>
    public class LicenseObjectBase
    {
        /// <summary>
        /// Client Code
        /// </summary>
        public string ClientCode { get; set; }
        /// <summary>
        /// Project Code
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Certificate
        /// </summary>
        public string Certificate { get; set; }
        /// <summary>
        /// Issued
        /// </summary>
        public DateTime Issued { get; set; }
        /// <summary>
        /// Expired
        /// </summary>
        public DateTime Expired { get; set; }
    }
}