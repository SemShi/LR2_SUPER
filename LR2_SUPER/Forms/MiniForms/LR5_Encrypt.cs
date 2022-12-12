using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2_SUPER.Forms.MiniForms
{
    public partial class LR5_Encrypt : UserControl
    {
        public LR5_Encrypt()
        {
            InitializeComponent();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            btNext.Enabled = false;
            btBack.Enabled = true;
            lR5_2page1.Visible = true;
            lR5_1page1.Visible= false;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            btNext.Enabled = true;
            btBack.Enabled = false;
            lR5_2page1.Visible = false;
            lR5_1page1.Visible = true;
        }
    }
}
