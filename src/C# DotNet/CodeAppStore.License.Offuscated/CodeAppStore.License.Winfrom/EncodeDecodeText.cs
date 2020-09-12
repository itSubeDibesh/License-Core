using CodeAppStore.License.EncodeDecodeRepo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeAppStore.License.WinFrom
{
    public partial class EncodeDecodeText : Form
    {
        readonly IEncodeDecode _encodeDecode = new EncodeDecode();
        private bool _Dragging; //Var Decleration for Dragable Form
        private Point _start_point = new Point(0, 0); //Var Decleration for Dragable Form
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


        private void richTextBoxEncode_TextChanged(object sender, EventArgs e)
        {
            richTextBoxEncode.Text = richTextBoxEncode.Text.TrimStart().TrimEnd().Trim();
        }

        private void richTextBoxDecode_TextChanged(object sender, EventArgs e)
        {
            richTextBoxDecode.Text = richTextBoxDecode.Text.TrimStart().TrimEnd().Trim();
        }

        private void EncodeDecodeText_MouseDown(object sender, MouseEventArgs e)
        {
            _Dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void EncodeDecodeText_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Dragging)
            {
                var p = PointToScreen(e.Location);
                Location = new Point(p.X - _start_point.X, p.Y - _start_point.Y);
            }
        }

        private void EncodeDecodeText_MouseUp(object sender, MouseEventArgs e)
        {
            _Dragging = false;
        }
    }
}
