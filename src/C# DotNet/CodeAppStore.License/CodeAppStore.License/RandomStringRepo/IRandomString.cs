namespace CodeAppStore.License.RandomStringRepo
{
    /// <summary>
    /// Random String interface
    /// </summary>
    public interface IRandomString
    {
        /// <summary>
        /// Generates random string according to <see cref="RandomStringPurpose"/> and can return uppercase or lowercase as well
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="maxSize"></param>
        /// <param name="capital"></param>
        /// <param name="small"></param>
        /// <returns>
        ///    Random String according to <see cref="RandomStringPurpose"/> <see cref="string"/>
        /// </returns>
        string RandomStringGenerator(short purpose, int maxSize = 52, bool capital = false, bool small = false);
    }
}