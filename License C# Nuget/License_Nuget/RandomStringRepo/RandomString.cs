using System;
using System.Text;

namespace License_Nuget.RandomStringRepo
{
    /// <summary>
    /// Random String Class
    /// </summary>
    public class RandomString : IRandomString
    {
        /// <summary>
        /// Uses different characters for different random string as per <see cref="RandomStringPurpose"/>
        /// </summary>
        private readonly string[] _dictionary =
        {
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-@!#+.",
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890",
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
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
                    var password = Password(maxSize, purpose);
                    return capital == true ? (UpperCase(password)) : small == true ? (LowerCase(password)) : (password);
                case 1:
                    var id = Id(maxSize, purpose);
                    return capital == true ? (UpperCase(id)) : small == true ? (LowerCase(id)) : (id);
                case 2:
                    var token = Token(maxSize, purpose);
                    return capital == true ? (UpperCase(token)) : small == true ? (LowerCase(token)) : (token);
                default:
                    var defaultStr = "rAnD0mSt3n.g68h9u1q8.aPm.DiBeSh.RaJ.SuBeDi.BySyStEmCoDeApPsToRe";
                    return capital == true ? (UpperCase(defaultStr)) : small == true ? (LowerCase(defaultStr)) : (defaultStr);
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
            return ("p@sSw0rd" + RndString(maxSize, _dictionary[purpose]) + "BySyStEmCoDeApPsToRe");
        }

        /// <summary>
        /// Generates Random String
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="purpose"></param>
        /// <returns><see cref="string"/></returns>
        protected string Id(int maxSize, short purpose)
        {
            return ("uId" + RndString(maxSize, _dictionary[purpose]));
        }

        /// <summary>
        /// Generates random token
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="purpose"></param>
        /// <returns><see cref="string"/></returns>
        protected string Token(int maxSize, short purpose)
        {
            return ("tOkEN" + RndString(maxSize, _dictionary[purpose]) + "BySyStEmCoDeApPsToRe");
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
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            var stringLength = random.Next((int)(min.HasValue ? min : _minSize), maxSize + 1);
            while (stringLength-- > 0)
            {
                stringBuilder.Append(dictionary[random.Next(dictionary.Length)]);
            }
            var password = stringBuilder.ToString();
            return password;
        }

    }
}