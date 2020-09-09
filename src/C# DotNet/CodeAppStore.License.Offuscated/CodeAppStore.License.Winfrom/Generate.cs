using CodeAppStore.License.EncodeDecodeRepo;
using CodeAppStore.License.LicenseRepo;
using System;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class Generate : Form
    {
        private readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        private readonly ILicense _license = new CodeAppStore.License.LicenseRepo.License();
        public Generate()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            var clientCode = _license.GenerateClientCode(textBoxEmail.Text);
            var projectCode = _license.GenerateProjectCode(textBoxProjectName.Text);
            var certificate = _license.GenerateCertificate(clientCode, projectCode);


            var license = _license.GenerateLicense(clientCode, certificate, dateTimePickerIssued.Value,
                dateTimePickerExpired.Value);

            textBoxClientCode.Text = _encodeDecode.Encrypt(clientCode);
            textBoxClient.Text = clientCode;

            textBoxProjectCode.Text = _encodeDecode.Encrypt(projectCode);
            textBoxProduct.Text = projectCode;

            textBoxCertificate.Text = _encodeDecode.Encrypt(certificate);
            textBoxCert.Text = certificate;

            textBoxLicense.Text = _encodeDecode.Encrypt(license);
            textBoxLice.Text = license;
        }

        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            WinFrom.License license = new WinFrom.License();
            license.Show();
            this.Hide();
        }
    }
}
