namespace MyTextBox
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class CustomTextBox : TextBox
    {
        private const int WM_PASTE = 0x0302;

        public CustomTextBox()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "CustomTextBox";
            this.Size = new System.Drawing.Size(217, 20);
            this.TabIndex = 0;
            this.TextChanged += this.textBox1_TextChanged;
            this.KeyPress += this.textBox1_KeyPress;
        }


        // Taken from http://net-informations.com/q/faq/txtbox.html
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double outValue;
            if (System.Text.RegularExpressions.Regex.IsMatch(this.Text, "  ^ [0-9]"))
            {
                this.Text = "";
            }
            else if (double.TryParse(this.Text, out outValue))
            {
                if (outValue >= 50)
                {
                    this.ForeColor = Color.Red;
                }
                else
                {
                    this.ForeColor = Color.Black;
                }
            }
        }

        // Taken from http://net-informations.com/q/faq/txtbox.html
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        // the idea has been taken from: https://stackoverflow.com/questions/15987712/handle-a-paste-event-in-c-sharp
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE)
            {
                base.WndProc(ref m);
            }
            else
            {
                double outValue;
                if (System.Text.RegularExpressions.Regex.IsMatch(Clipboard.GetText(), "  ^ [0-9]"))
                {
                    this.Text = "";
                }
                else if (double.TryParse(Clipboard.GetText(), out outValue))
                {
                    if (outValue >= 50)
                    {
                        this.Text = Clipboard.GetText();
                        this.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.Text = Clipboard.GetText();
                        this.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
