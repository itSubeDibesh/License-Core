using CodeAppStore.License.LicenseRepo;
using System;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class License : Form
    {
        private ILicense _license;
        public License()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            Reset();
        }

        protected void Reset()
        {
            textBoxProjectCode.Clear();
            textBoxCertificate.Clear();
            richTextBoxLicense.Clear();
            textBoxClientCode.Clear();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void ButtonVerify_Click(object sender, EventArgs e)
        {

            if (textBoxCertificate.Text != null && textBoxClientCode.Text != null && textBoxProjectCode.Text != null &&
                richTextBoxLicense.Text != null)
            {
                _license = new CodeAppStore.License.LicenseRepo.License(); ;
                try
                {
                    var result = _license.CheckLicenseVerification(richTextBoxLicense.Text, textBoxCertificate.Text,
                        textBoxClientCode.Text, textBoxProjectCode.Text);
                    MessageBox.Show("Is Valid : " + result.IsValid + ", Is Expired : " + result.IsExpired +
                                    ", Expiry : " + result.Expiry, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Some fields might be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientCode.Focus();
            }
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            var generate = new Generate_New();
            generate.Show();
            this.Hide();
        }

        private void ButtonExistingInformation_Click(object sender, EventArgs e)
        {
            var generate = new Generate_Existing();
            generate.Show();
            this.Hide();
        }

        private void ButtonEncodeDecode_Click(object sender, EventArgs e)
        {
            EncodeDecodeText encodeDecode = new EncodeDecodeText();
            encodeDecode.Show();
            this.Hide();
        }
    }
}
