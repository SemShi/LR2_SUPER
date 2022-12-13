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
using LR2_SUPER.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void btReset_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
            lR5_1page1.Msg = "";
            lR5_1page1.P = "";
            lR5_1page1.G = "";
            lR5_1page1.Y = "";
            lR5_2page1.SessionKey = "";
            lR5_2page1.SecretKey = "";
        }

        private void cbMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMode.Checked)
            {
                lR5_1page1.onOffTextBoxes(true);
                lR5_2page1.onOffTextBoxes(true);
            }
            else
            {
                lR5_1page1.onOffTextBoxes(false);
                lR5_2page1.onOffTextBoxes(false);
            }
                
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lR5_1page1.Msg))
            {
                MessageBox.Show("Отсутствует открытое сообщение.", "Ошибка!");
                return;
            }

            if (!cbMode.Checked)
            {
                if (string.IsNullOrWhiteSpace(lR5_1page1.P) || string.IsNullOrWhiteSpace(lR5_1page1.G) || string.IsNullOrWhiteSpace(lR5_1page1.Y))
                {
                    MessageBox.Show("Отсутствует одно из начений {P,G,Y}.", "Ошибка!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(lR5_2page1.SessionKey))
                {
                    MessageBox.Show("Отсутствует сессионный ключ.", "Ошибка!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(lR5_2page1.SecretKey))
                {
                    MessageBox.Show("Отсутствует закрытый ключ ключ.", "Ошибка!");
                    return;
                }
            }
            if (cbMode.Checked)
            {
                byte[] ZnchChar = new byte[lR5_1page1.Msg.Length];
                 int simpleNum = LrHelper.GetSimple();
                int g = LrHelper.GetPRoot(simpleNum);
                var rnd = new Random();
                int x = rnd.Next(2, simpleNum - 1);
                int y = LrHelper.BigPow(g, x, simpleNum);
                int sessionKey = 0;

                do
                {
                    sessionKey = rnd.Next(2, simpleNum - 1);
                } while (!LrHelper.IsPRoot(sessionKey, simpleNum - 1));

                if (cbShowProcess.Checked)
                {
                    tbResult.AppendText($@"======Расчеты======
Выбрано просто число p - {simpleNum};
Первообразный корень g - {g};
Закрытый ключ x - {x};
y - {y};
Сессионный ключ - {sessionKey};{Environment.NewLine}");
                }

                int a = LrHelper.BigPow(g, sessionKey, simpleNum);
                BigInteger YVStepK = BigInteger.ModPow(y, sessionKey, simpleNum);
                string EncryptedMsg = "";
                int b;
                for (int i = 0; i < lR5_1page1.Msg.Length; i++)
                {
                    ZnchChar[i] = Convert.ToByte(lR5_1page1.Msg[i]);
                    b = (int)BigInteger.ModPow(YVStepK * ZnchChar[i], 1, simpleNum);
                    EncryptedMsg += a + "," + b + " ";
                }

                tbResult.AppendText($@"Шифрограмма - {EncryptedMsg}");
            }
            else
            {

            }

            
        }
    }
}
