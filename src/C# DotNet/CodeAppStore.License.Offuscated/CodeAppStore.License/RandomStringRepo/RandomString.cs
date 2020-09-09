using CodeAppStore.License.EncodeDecodeRepo;
using CodeAppStore.License.Models;
using System;
using System.Text;

namespace CodeAppStore.License.RandomStringRepo
{
    /// <summary>
    /// Random String Class
    /// </summary>
    public class RandomString : EncodeDecode, IRandomString
    {
        /// <summary>
        /// Uses different characters for different random string as per <see cref="RandomStringPurpose"/>
        /// </summary>
        static readonly SecretsObject O90DFL = new SecretsObject();
        private readonly string[] _dictionary =
        {
            O90DFL._DS+"_-@!#+.",
            O90DFL._DS,
            O90DFL._DS+"_"
        };
        private readonly int _minSize = 6;

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
        public string RandomStringGenerator(short purpose, int maxSize = 52, bool capital = false, bool small = false)
        {
            switch (purpose)
            {
                case 0:
                    var pwsae9j = Password(maxSize, purpose);
                    return capital == true ? (UpperCase(pwsae9j)) : small == true ? (LowerCase(pwsae9j)) : (pwsae9j);
                case 1:
                    var i9hj = Id(maxSize, purpose);
                    return capital == true ? (UpperCase(i9hj)) : small == true ? (LowerCase(i9hj)) : (i9hj);
                case 2:
                    var tk0hj = Token(maxSize, purpose);
                    return capital == true ? (UpperCase(tk0hj)) : small == true ? (LowerCase(tk0hj)) : (tk0hj);
                default:
                    var df9hjk = "rAnD0mSt3n.g68h9u1q8.aPm.DiBeSh.RaJ.SuBeDi." + O90DFL._CST;
                    return capital == true ? (UpperCase(df9hjk)) : small == true ? (LowerCase(df9hjk)) : (df9hjk);
            }
        }

        /// <summary>
        /// Generates random password
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="purpose"></param>
        /// <returns><see cref="string"/></returns>
        protected string Password(int maxSize, short purpose)
        {
            return (O90DFL._PW + RndString(maxSize, _dictionary[purpose]) + O90DFL._CST);
        }

        /// <summary>
        /// Generates Random String
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="purpose"></param>
        /// <returns><see cref="string"/></returns>
        protected string Id(int maxSize, short purpose)
        {
            return (O90DFL._UI + RndString(maxSize, _dictionary[purpose]));
        }

        /// <summary>
        /// Generates random token
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="purpose"></param>
        /// <returns><see cref="string"/></returns>
        protected string Token(int maxSize, short purpose)
        {
            return (O90DFL._TK + RndString(maxSize, _dictionary[purpose]) + O90DFL._CST);
        }

        /// <summary>
        /// Converts normal string to uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <returns>UPPERCASE STRING <see cref="string"/></returns>
        protected string UpperCase(string input)
        {
            return input.ToUpperInvariant();
        }

        /// <summary>
        /// Converts to lowercase string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>lowercase string <see cref="string"/></returns>
        protected string LowerCase(string input)
        {
            return input.ToLowerInvariant();
        }

        /// <summary>
        /// Generates random string using the predefined <see cref="_dictionary"/>
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="dictionary"></param>
        /// <param name="min"></param>
        /// <returns> Random String <see cref="string"/></returns>
        protected string RndString(int maxSize, string dictionary, int? min = null)
        {
            StringBuilder sb9hjl = new StringBuilder();
            Random ran9hjk = new Random();
            var sl9hk = ran9hjk.Next((int)(min.HasValue ? min : _minSize), maxSize + 1);
            while (sl9hk-- > 0)
            {
                sb9hjl.Append(dictionary[ran9hjk.Next(dictionary.Length)]);
            }
            var pw9hjl = sb9hjl.ToString();
            return pw9hjl;
        }

    }
}