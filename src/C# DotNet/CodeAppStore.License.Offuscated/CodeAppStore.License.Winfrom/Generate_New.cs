using CodeAppStore.License.EncodeDecodeRepo;
using CodeAppStore.License.LicenseRepo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class Generate_New : Form
    {
        private readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        private readonly ILicense _license = new CodeAppStore.License.LicenseRepo.License();
        private bool _Dragging; //Var Decleration for Dragable Form
        private Point _start_point = new Point(0, 0); //Var Decleration for Dragable Form
        public Generate_New()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerIssued.Value >= DateTime.Now)
            {
                dateTimePickerIssued.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
            }
            if (!string.IsNullOrWhiteSpace(textBoxProjectName.Text) && !string.IsNullOrWhiteSpace(textBoxEmail.Text))
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
            else
            {
                MessageBox.Show("Project Name, Email, issued Date and Expiry Date are required");
                return;
            }
        }

        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            WinFrom.License license = new WinFrom.License();
            license.Show();
            this.Hide();
        }

        private void Generate_New_MouseDown(object sender, MouseEventArgs e)
        {
            _Dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Generate_New_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Dragging)
            {
                var p = PointToScreen(e.Location);
                Location = new Point(p.X - _start_point.X, p.Y - _start_point.Y);
            }
        }

        private void Generate_New_MouseUp(object sender, MouseEventArgs e)
        {
            _Dragging = false;
        }
    }
}
