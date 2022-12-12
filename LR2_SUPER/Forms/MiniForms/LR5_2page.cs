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
    public partial class LR5_2page : UserControl
    {
        public LR5_2page()
        {
            InitializeComponent();
        }

        public string SessionKey { get { return this.tbSessionKey.Text; } }
        public string SecretKey { get { return this.tbSecretKey.Text; } }
    }
}
