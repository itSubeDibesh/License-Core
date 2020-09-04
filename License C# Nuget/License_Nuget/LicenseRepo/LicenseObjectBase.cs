using System;

namespace License_Nuget.LicenseRepo
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
        public string ClientCode { get; set; }
        public string ProjectCode { get; set; }
        public string Certificate { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expired { get; set; }
    }
}