using System.Text;
using LR2_SUPER.Helpers;

namespace LR2_SUPER.Forms.MiniForms
{
    public partial class Task2_LR2 : UserControl
    {
        private char[] alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ".ToCharArray();
        public Task2_LR2()
        {
            InitializeComponent();
        }

        private static int Find_Char(char ch, char[] alphabet) //Нахождение индекса символа в массиве
        {
            for (var i = 0; i < alphabet.Length; i++)
            {
                if (ch == alphabet[i]) return i;
            }
            return -1;
        }

        private static string XOR(string x, string y) //Двоичное исключающее ИЛИ
        {
            string result = String.Empty;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        public string Encryption_mod2(string input) //Зашифрование mod N
        {
            input = input.ToLower().Replace(" ", "");
            string gammaBinary = BBS.BuildingBBS(Convert.ToInt64(tbX.Text), BBS.Calculate_m(Convert.ToInt64(tbP.Text), Convert.ToInt64(tbQ.Text)), tbMsg.Text.Replace(" ", "").Length);
            byte[] inputTemp;
            string inputBinary = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                //inputBinary += Convert.ToString(input[i], 2);
                inputTemp = Encoding.GetEncoding(1251).GetBytes(input);
                inputBinary += Convert.ToString(inputTemp[i], 2);
            }
            string resultBinary = XOR(inputBinary, gammaBinary);
            byte[] resultTemp = new byte[resultBinary.Length / 8];
            string result = String.Empty;
            for (int i = 0; i < resultBinary.Length; i += 8)
            {
                string resultBinarySubstring = resultBinary.Substring(i, 8);
                byte bv = Convert.ToByte(resultBinarySubstring, 2);
                resultTemp[i / 8] = bv;
            }
            result += Encoding.GetEncoding(1251).GetString(resultTemp);
            return result;
        }

        public string Decryption_mod2(string input) //Расшифрование mod N
        {
            input = input.ToLower();
            string gammaBinary = BBS.BuildingBBS(Convert.ToInt64(tbX.Text), BBS.Calculate_m(Convert.ToInt64(tbP.Text), Convert.ToInt64(tbQ.Text)), tbMsg.Text.Replace(" ", "").Length);
            byte[] inputTemp;
            string inputBinary = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                //inputBinary += Convert.ToString(input[i], 2);
                inputTemp = Encoding.GetEncoding(1251).GetBytes(input);
                inputBinary += Convert.ToString(inputTemp[i], 2).PadLeft(8, '0');
            }
            string resultBinary = XOR(inputBinary, gammaBinary);
            byte[] resultTemp = new byte[resultBinary.Length / 8];
            string result = String.Empty;
            for (int i = 0; i < resultBinary.Length; i += 8)
            {
                string resultBinarySubstring = resultBinary.Substring(i, 8);
                byte bv = Convert.ToByte(resultBinarySubstring, 2);
                resultTemp[i / 8] = bv;
            }
            result += Encoding.GetEncoding(1251).GetString(resultTemp);
            return result.ToLower();
        }

        private void Task2_LR2_Load(object sender, EventArgs e)
        {
            btGo.Text = rbEncrypt.Checked ? "Зашифровать" : "Расшифровать";
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            if (!IsTbEmpty(tbMsg.Text, tbP.Text, tbQ.Text, tbX.Text))
            {
                MessageBox.Show("Заполните поля", "Ошибка!");
                return;
            }
            if (rbEncrypt.Checked)
            {
                tbResult.Text = Encryption_mod2(tbMsg.Text);
            }
            else
            {
                tbResult.Text = Decryption_mod2(tbMsg.Text);
            }
        }

        private bool IsTbEmpty(params string[] values)
        {
            foreach(var value in values)
            {
                if (string.IsNullOrWhiteSpace(value)) return false;
            }
            return true;
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
            tbP.Clear();
            tbQ.Clear();
            tbX.Clear();
            tbResult.Clear();
        }
    }
}
