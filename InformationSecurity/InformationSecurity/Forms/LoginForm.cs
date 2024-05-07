using InformationSecurity.Classes;
using InformationSecurity.Forms;
using InformationSecurity.Forms.Organizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity
{
    public partial class LoginForm : Form
    {
        int loginAttempts = 0;
        public LoginForm()
        {
            InitializeComponent();

            // Проверяем, есть ли сохранненые учетные данные пользователя
            CheckCredentials();
        }

        private void CheckCredentials()
        {
            if (File.Exists("credentials.txt"))
            {
                try
                {
                    string data = File.ReadAllText("credentials.txt");
                    string[] credentials = data.Split(',');

                    if (credentials.Length == 2)
                    {
                        tbLogin.Text = credentials[0];
                        tbPassword.Text = credentials[1];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка. Не удалось заполнить учетные данные: {ex.Message}");
                    WarningMessage("Не удалось заполнить учетные данные.");
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // validation data
            if (string.IsNullOrEmpty(tbLogin.Text.Trim()) || string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                WarningMessage("Пожалуйста, заполните все поля.");
                return;
            }

            if (!int.TryParse(tbLogin.Text.Trim(), out int _))
            {
                WarningMessage("Поле IdNumber должно содержать только целые числа.");
                return;
            }


            // login
            try
            {
                string login = tbLogin.Text.Trim();
                string password = tbPassword.Text.Trim();

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("LoginCheck", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                UserData userData = new UserData(reader);

                                if (chbRememberMe.Checked == true)
                                {
                                    try
                                    {
                                        string data = $"{login},{password}";
                                        File.WriteAllText("credentials.txt", data);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Ошибка. Не удалось запомнить учетные данные: {ex.Message}");
                                        WarningMessage("Не удалось запомнить учетные данные.");
                                    }
                                }

                                MessageBox.Show("Добро пожаловать.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                OrganizerForm organizerForm = new OrganizerForm();
                                organizerForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                loginAttempts++;
                                WarningMessage("Пользователя с такими IdNumber и Password не существует.");

                                if (loginAttempts > 2)
                                {
                                    CaptchForm captch = new CaptchForm();
                                    captch.ShowDialog();

                                    if (captch.isCorrectAnswer == false)
                                    {
                                        WarningMessage("Возможность входа заблокирована на 10 сек.");

                                        DisableUserInput();
                                        await Task.Delay(10000);
                                        EnableUserInput();
                                    }
                                }

                                return;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Ошибка авторизации: {sqlEx.Message}");
                ErrorMessage("Проверьте подключение к базе данных.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                ErrorMessage("Произошла непредвиденная ошибка.");
            }
        }

        private void EnableUserInput()
        {
            tbLogin.Enabled = true;
            tbPassword.Enabled = true;
            btnLogin.Enabled = true;
            chbRememberMe.Enabled = true;
        }

        private void DisableUserInput()
        {
            tbLogin.Enabled = false;
            tbPassword.Enabled = false;
            btnLogin.Enabled = false;
            chbRememberMe.Enabled = false;
        }

        private void WarningMessage(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = Application.OpenForms["GuestForm"];
            form.Show();
        }
    }
}
