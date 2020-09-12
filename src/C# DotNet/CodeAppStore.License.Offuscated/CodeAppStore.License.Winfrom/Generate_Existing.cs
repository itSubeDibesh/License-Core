using CodeAppStore.License.EncodeDecodeRepo;
using CodeAppStore.License.LicenseRepo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class Generate_Existing : Form
    {
        private readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        private readonly ILicense _license = new CodeAppStore.License.LicenseRepo.License();
        private bool _Dragging; //Var Decleration for Dragable Form
        private Point _start_point = new Point(0, 0); //Var Decleration for Dragable Form
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

            if (string.IsNullOrWhiteSpace(textBoxProjectCode.Text) && string.IsNullOrWhiteSpace(textBoxClientCode.Text))
            {
                MessageBox.Show("(Client Code and Project code) Or Unique Key required", "No input Found");
                return;
            }
            else
            {
                if (dateTimePickerIssued.Value >= DateTime.Now)
                {
                    dateTimePickerIssued.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                }

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
                return;

            }

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

        private void TextBoxUniqueKey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUniqueKey.Text)) return;
            var input = textBoxUniqueKey.Text.Trim(' ').TrimStart(' ').TrimEnd(' ');
            var decryptedInput = _encodeDecode.Decrypt(input);
            var decryptedInputDotIndex = decryptedInput.LastIndexOf('.');
            var decryptedInputLength = decryptedInput.Length;
            textBoxClientCode.Text =
                decryptedInput.Remove(decryptedInputDotIndex, decryptedInputLength - decryptedInputDotIndex);
            textBoxProjectCode.Text = decryptedInput
                .Substring(decryptedInputDotIndex, decryptedInputLength - decryptedInputDotIndex).Replace(".", "")
                .Trim();
        }

        private void Generate_Existing_MouseDown(object sender, MouseEventArgs e)
        {
            _Dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Generate_Existing_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Dragging)
            {
                var p = PointToScreen(e.Location);
                Location = new Point(p.X - _start_point.X, p.Y - _start_point.Y);
            }
        }

        private void Generate_Existing_MouseUp(object sender, MouseEventArgs e)
        {
            _Dragging = false;
        }

    }
}
