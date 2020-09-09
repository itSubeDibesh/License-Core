using CodeAppStore.License.EncodeDecodeRepo;
using System;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class EncodeDecodeText : Form
    {
        readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        public EncodeDecodeText()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            License license = new License();
            license.Show();
            this.Hide();
        }

        private void ButtonEncode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBoxEncode.Text))
            {
                richTextBoxDecode.Text = "";
                richTextBoxDecode.Text = _encodeDecode.Encrypt(richTextBoxEncode.Text);
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            richTextBoxDecode.Text = "";
            richTextBoxEncode.Text = "";
        }

        private void ButtonDecode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBoxDecode.Text))
            {
                richTextBoxEncode.Text = "";
                richTextBoxEncode.Text = _encodeDecode.Decrypt(richTextBoxDecode.Text);
            }
        }
    }
}
