using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCustomTextBox
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            MyBox textBox = new MyBox();
            this.tableLayoutPanel1.Controls.Add(textBox, 0, 0);
        }
    }
}
