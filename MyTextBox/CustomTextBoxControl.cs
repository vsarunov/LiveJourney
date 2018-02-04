namespace MyTextBox
{
    using System.Windows.Forms;

    public partial class CustomTextBoxController : UserControl
    {
        public CustomTextBoxController()
        {
            InitializeComponent();
            CustomTextBox textBox = new CustomTextBox();
            this.tableLayoutPanel1.Controls.Add(textBox, 0, 0);
        }
    }
}
