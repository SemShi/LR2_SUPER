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
    public partial class LR5_Decrypt : UserControl
    {
        public LR5_Decrypt()
        {
            InitializeComponent();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            tbP.Clear();
            tbX.Clear();
            tbResult.Clear();
            tbSecretMsg.Clear();
        }
    }
}
