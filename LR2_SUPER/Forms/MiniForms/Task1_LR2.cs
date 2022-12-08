using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2_SUPER.Forms
{
    public partial class Task1_LR2 : UserControl
    {
        private char[] alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();

        public Task1_LR2()
        {
            InitializeComponent();
        }

        private void StartEncrypt()
        {
            char[] msg = tbMsg.Text.ToUpper().ToCharArray();
            char[] gamma = tbGamma.Text.ToUpper().ToCharArray();
            string newMsg = null;

            if (msg.Length > gamma.Length)
            {
                MessageBox.Show($"Добавьте в гамму {msg.Length - gamma.Length} символов", "Ошибка!");
                return;
            }


            for (int i = 0; i < msg.Length; i++)
            {
                bool gotMsg = false;
                bool gotGamma = false;
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (msg[i] == ' ')
                    {
                        msg[i] = ' ';
                        break;
                    }
                    if (msg[i] == alphabet[j])
                    {
                        msg[i] = Convert.ToChar(j);
                        gotMsg = true;
                    }

                    if (gamma[i] == alphabet[j])
                    {
                        gamma[i] = Convert.ToChar(j);
                        gotGamma = true;
                    }
                    if (gotMsg && gotGamma) break;
                }
            }

            int num;
            if (rbEncrypt.Checked)
            {
                for (int i = 0; i < msg.Length; i++)
                {
                    if (msg[i] == ' ')
                    {
                        newMsg += ' ';
                    }
                    else
                    {
                        num = Convert.ToInt32(msg[i]) - Convert.ToInt32(gamma[i]);
                        if (num >= 0)
                        {
                            num = num % 33;
                        }
                        else
                        {
                            num = (33 + num);
                        }
                        newMsg += alphabet[num];
                    }
                }
                tbResult.Text = newMsg;
                return;
            }
            else
            {
                for (int i = 0; i < msg.Length; i++)
                {
                    if (msg[i] == ' ')
                    {
                        newMsg += ' ';
                    }
                    else
                    {
                        num = (Convert.ToInt32(msg[i]) + Convert.ToInt32(gamma[i])) % 33;
                        newMsg += alphabet[num];
                    }
                }
                tbResult.Text = newMsg;
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMsg.Text) || string.IsNullOrWhiteSpace(tbGamma.Text))
            {
                MessageBox.Show("Заполните поля", "Ошибка!");
                return;
            }
            StartEncrypt();
        }

        private void rbs_CheckedChanged(object sender, EventArgs e)
        {
            btGo.Text = ((RadioButton)sender).Text;
            if (rbDecrypt.Checked && !string.IsNullOrWhiteSpace(tbResult.Text))
                tbMsg.Text = tbResult.Text;
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            tbMsg.Clear();
            tbGamma.Clear();
            tbResult.Clear();
            rbEncrypt.Checked = true;
        }

        private void Task1_LR2_Load(object sender, EventArgs e)
        {
            btGo.Text = rbEncrypt.Checked ? "Зашифровать" : "Расшифровать";
        }
    }
}
