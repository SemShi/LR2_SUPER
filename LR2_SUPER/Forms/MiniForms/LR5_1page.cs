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
    public partial class LR5_1page : UserControl
    {
        public LR5_1page()
        {
            InitializeComponent();
        }

        public string Msg { get { return this.tbMsg.Text; } set { tbMsg.Text = value; } }
        public string P { get { return this.tbP.Text; } set { tbP.Text = value; } }
        public string G { get { return this.tbG.Text; } set { tbG.Text = value; } }
        public string Y { get { return this.tbY.Text; } set { tbY.Text = value; } }

        public void onOffTextBoxes(bool isChecked)
        {
            if (isChecked)
            {
                tbG.Enabled = false;
                tbP.Enabled = false;
                tbY.Enabled = false;
            }
            else
            {
                tbG.Enabled = true;
                tbP.Enabled = true;
                tbY.Enabled = true;
            }
            
        }

    }
}
