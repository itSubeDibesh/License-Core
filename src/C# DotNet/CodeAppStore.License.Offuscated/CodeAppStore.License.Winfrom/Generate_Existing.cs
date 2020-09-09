using CodeAppStore.License.EncodeDecodeRepo;
using CodeAppStore.License.LicenseRepo;
using System;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class Generate_Existing : Form
    {
        private readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        private readonly ILicense _license = new CodeAppStore.License.LicenseRepo.License();
        public Generate_Existing()
        {
            InitializeComponent();
        }

        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            License license = new License();
            license.Show();
            this.Hide();
        }

        private void ButtonGenerateNewLicense_Click(object sender, EventArgs e)
        {
            // New Certificate
            var newCertificate = _license.GenerateCertificate(textBoxClientCode.Text, textBoxProjectCode.Text);
            textBoxCertificate.Text = newCertificate;

            // New Encrypted Certificate
            var encryptedCertificate = _encodeDecode.Encrypt(newCertificate);
            textBoxEncryptedCertificate.Text = encryptedCertificate;

            // New License
            var newLicense = _license.GenerateLicense(textBoxClientCode.Text, newCertificate, dateTimePickerIssued.Value,
                dateTimePickerExpired.Value);
            richTextBoxLicense.Text = newLicense;

            // New Encrypted License
            var encryptedNewLicense = _encodeDecode.Encrypt(newLicense);
            richTextBoxEncryptedLicense.Text = encryptedNewLicense;

            // Combine New Certificate and License
            var combinedLicense = newLicense + @"." + newCertificate;
            richTextBoxCombinedLicense.Text = combinedLicense;

            // Encrypted Combined  License
            var encryptedCombinedLicense = _encodeDecode.Encrypt(combinedLicense);
            richTextBoxCombinedEncryptedLicense.Text = encryptedCombinedLicense;

            #region Extracting License and Certificate from Combined License
            /*
            //length of Combined License
            var lengthOfCombinedLicense = combinedLicense.Length;

            // Index of . from licenseString
            var indexOfDot = Convert.ToInt32(combinedLicense.LastIndexOf('.'));

            // LetterCount Of Certificate
            var letterCountOfCertificate = lengthOfCombinedLicense - indexOfDot;

            // Extracted License
            var extractedLicense = combinedLicense.Substring(0, indexOfDot);

            // Extract certificate
            var extractedCertificate = combinedLicense.Substring(indexOfDot, letterCountOfCertificate).Replace(".", "");
            */
            #endregion

        }
    }
}
