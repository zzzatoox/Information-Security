using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity.Forms
{
    public partial class CaptchForm : Form
    {
        public bool isCorrectAnswer = false;
        private string captchAnswer;
        public CaptchForm()
        {
            InitializeComponent();

            pbCaptch.Image = GenerateCaptch();
        }

        private Bitmap GenerateCaptch()
        {
            Random random = new Random();
            Bitmap bitmap = new Bitmap(pbCaptch.Width, pbCaptch.Height);

            int Xpos = random.Next(5, pbCaptch.Width - 70);
            int Ypos = random.Next(0, pbCaptch.Height - 25);

            Brush[] colors = { Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Orange, Brushes.Orchid, Brushes.Purple };

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.LightGray);

            captchAnswer = new string(Enumerable.Repeat("1234567890QWERTYUIOPASDFGHJKLZXCVBNM", 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            for (int i = 0; i < 4; i++)
            {
                graphics.DrawString(captchAnswer[i].ToString(), new Font("Arial", 20), colors[random.Next(colors.Length)], new PointF(Xpos + (i * 10), Ypos + (random.Next(-2, 3) * 3)));
            }

            return bitmap;
        }

        private void btnEnterCaptch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCaptch.Text.Trim()))
            {
                WarningMessage("Необходимо заполнить поле для ввода капчи.");
                return;
            }

            if (tbCaptch.Text.Trim().ToLower() == captchAnswer.ToLower())
            {
                MessageBox.Show("Капча пройдена успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isCorrectAnswer = true;
                this.Close();
            }
            else
            {
                WarningMessage("Капча введа неверно.");
                isCorrectAnswer = false;
                this.Close();
            }
        }

        private void WarningMessage(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pbCaptch.Image = GenerateCaptch();
        }
    }
}
