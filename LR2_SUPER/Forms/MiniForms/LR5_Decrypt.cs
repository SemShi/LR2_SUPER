using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void btGo_Click(object sender, EventArgs e)
        {
            string[] sipher = tbSecretMsg.Text.Split(' ');
            foreach (var ch in sipher)
            {
                bool smena = true;
                string a = null, b = null;
                for (int i = 0; i < ch.Length; i++)
                {
                    if (ch[i] == ',')
                    {
                        smena = false;
                    }
                    else if (smena == false)
                    {
                        b += ch[i];
                    }
                    else a += ch[i];
                }

                int A = Convert.ToInt32(a);
                int B = Convert.ToInt32(b);
                int P = Convert.ToInt32(tbP.Text);
                int X = Convert.ToInt32(tbX.Text);

                int test = (int)BigInteger.ModPow(B * BigInteger.Pow(A, P - 1 - X), 1, P);

                tbResult.Text += (char)BigInteger.ModPow(B * BigInteger.Pow(A, P - 1 - X), 1, P);
            }
        }
    }
}
