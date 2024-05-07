using InformationSecurity.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace InformationSecurity.Forms.Organizer
{
    public partial class OrganizerForm : Form
    {
        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public OrganizerForm()
        {
            InitializeComponent();
            WelcomeUser();
        }

        private void WelcomeUser()
        {
            if (DateTime.Now.Hour < 12)
            {
                lblWelcome.Text = "Доброе утро!";
            }
            else if (DateTime.Now.Hour < 17)
            {
                lblWelcome.Text = "Добрый день!";
            }
            else { lblWelcome.Text = "Добрый вечер!"; }

            lblUser.Text = $"{UserData.LastName} {UserData.FirstName} {UserData.Patronymic}";
        }

        private void btnJuries_Click(object sender, EventArgs e)
        {
            RegJuryModerForm regJury = new RegJuryModerForm();
            regJury.ShowDialog();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            try
            {
                string photoPath = Path.Combine(projectDirectory, $"Resources\\Images\\{UserData.PhotoPath}");

                if (File.Exists(photoPath))
                {
                    pbPhoto.ImageLocation = photoPath;
                }
                else
                {
                    pbPhoto.ImageLocation = Path.Combine(projectDirectory, $"Resources\\Images\\defaultProfile.png");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось установить фотографию профиля: {ex.Message}");
                MessageBox.Show("Не удалось установить фотографию профиля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = Application.OpenForms["LoginForm"];
            form.Show();
        }
    }
}
