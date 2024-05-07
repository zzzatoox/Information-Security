using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity.Forms.Organizer
{
    public partial class RegJuryModerForm : Form
    {
        private string photoPath;
        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        private string userPhoto;

        public RegJuryModerForm()
        {
            InitializeComponent();
        }

        // Получаем IdNumber, на который зарегистрируем модератора/жюри
        private void RegJuryModerForm_Load(object sender, EventArgs e)
        {
            GetIdNumber();
            LoadGenders();
            LoadRoles();
            LoadDirections();
        }

        private void LoadDirections()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM DirectionsView", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            cbDirections.ValueMember = "id";
                            cbDirections.DisplayMember = "Направление";

                            cbDirections.DataSource = dataTable;
                            cbDirections.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить направления из представления: {sqlex.Message}");
                ErrorMessage("Не удалось получить направления.");
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить направления: {ex.Message}");
                ErrorMessage("Не удалось получить направления.");
                this.Close();
            }
        }

        private void LoadRoles()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM RolesView", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            cbRoles.ValueMember = "id";
                            cbRoles.DisplayMember = "Роль";
                            cbRoles.DataSource = dataTable;
                            cbRoles.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить роли из представления: {sqlex.Message}");
                ErrorMessage("Не удалось получить роли.");
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить роли: {ex.Message}");
                ErrorMessage("Не удалось получить роли.");
                this.Close();
            }
        }

        private void LoadGenders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM GendersView", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            cbGenders.ValueMember = "gender";
                            cbGenders.DisplayMember = "Пол";

                            cbGenders.DataSource = dataTable;
                            cbGenders.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить гендеры из представления: {sqlex.Message}");
                ErrorMessage("Не удалось получить гендеры.");
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить гендеры: {ex.Message}");
                ErrorMessage("Не удалось получить гендеры.");
                this.Close();
            }
        }

        private void GetIdNumber()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetIdNumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        int idNumber = Convert.ToInt32(command.ExecuteScalar());

                        tbIdNumber.Text = idNumber.ToString();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить IdNumber из хранимой процедуры: {sqlex.Message}");
                ErrorMessage("Не удалось сгенерировать уникальный IdNumber.");
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось получить IdNumber: {ex.Message}");
                ErrorMessage("Не удалось сгенерировать уникальный IdNumber.");
                this.Close();
            }
        }

        private void WarningMessage(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photoPath = openFileDialog.FileName;
                pbPhoto.Image = Image.FromFile(photoPath);
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (ValidateUserData())
            {
                try
                {
                    //get all user data
                    string[] fio = tbFIO.Text.Trim().Split();

                    string lastName = fio[0];
                    string firstName = fio[1];
                    string patronymic = fio.Length == 3 ? fio[2] : "";

                    int gender = Convert.ToInt32(cbGenders.SelectedValue);
                    int role = Convert.ToInt32(cbRoles.SelectedValue);
                    string email = tbEmail.Text.Trim();
                    string phoneNumber = mtbPhoneNumber.Text.Trim();
                    string direction = cbDirections.Text.Trim().ToLower();
                    string password = tbPassword.Text.Trim();

                    //save photo that user picked
                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        SavePhoto();
                    }

                    userPhoto = cbRoles.Text == "Модератор" ? $"moderators/{Path.GetFileName(photoPath)}" : $"juries/{Path.GetFileName(photoPath)}"; 

                    // reg user
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("RegJuryModerator", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@last_name", lastName);
                            command.Parameters.AddWithValue("@first_name", firstName);
                            command.Parameters.AddWithValue("@patronymic", patronymic);
                            command.Parameters.AddWithValue("@gender", gender);
                            command.Parameters.AddWithValue("@role_id", role);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@phone_number", phoneNumber);
                            command.Parameters.AddWithValue("@direction", direction);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@photo", userPhoto);

                            command.ExecuteNonQuery();
                        }
                    }

                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        SavePhoto();
                    }

                    MessageBox.Show("Вы успешно зарегистрировали пользователя.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (SqlException sqlex)
                {
                    Console.WriteLine($"Ошибка. Не удалось зарегистрировать пользователя: {sqlex.Message}");
                    ErrorMessage("Не удалось зарегистрировать пользователя.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                    ErrorMessage("Произошла непредвиденная ошибка.");
                }
            }
        }

        private void SavePhoto()
        {
            try
            {
                string destinationPath = Path.Combine(projectDirectory, $"Resources\\Images\\{userPhoto}");

                File.Copy(photoPath, destinationPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка. Не удалось сохранить выбранное изображение: {ex.Message}");
                WarningMessage("Не удалось сохранить выбранное Вами изображение.");
            }
        }

        private bool ValidateUserData()
        {
            if (string.IsNullOrEmpty(tbFIO.Text.Trim()) ||
                string.IsNullOrEmpty(tbEmail.Text.Trim()) ||
                string.IsNullOrEmpty(tbPassword.Text.Trim()) ||
                string.IsNullOrEmpty(tbPassword2.Text.Trim()) ||
                string.IsNullOrEmpty(cbDirections.Text) ||
                string.IsNullOrEmpty(mtbPhoneNumber.Text.Trim()))
            {
                WarningMessage("Необходимо заполнить все поля.");
                return false;
            }

            if (mtbPhoneNumber.Text.Trim().Length != 17)
            {
                WarningMessage("Неверный формат телефонного номера.");
                return false;
            }

            string[] data = tbFIO.Text.Trim().Split();

            if (data.Length == 1 || data.Length > 3)
            {
                WarningMessage("Неправильно введено ФИО.");
                return false;
            }

            if (tbPassword.Text.Trim() != tbPassword2.Text.Trim())
            {
                WarningMessage("Пароли не совпадают.");
                return false;
            }

            string password = tbPassword.Text.Trim();

            if (password.Length < 6)
            {
                WarningMessage("Длина пароля должна составлять не менее 6 символов.");
                return false;
            }

            if (!password.Any(char.IsUpper) && !password.Any(char.IsLower))
            {
                WarningMessage("Пароль должен содержать заглавные и строчные буквы.");
                return false;
            }

            if (password.IndexOfAny("!#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray()) == 0)
            {
                WarningMessage("Пароль должен содержать не менее одного спецсимвола.");
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                WarningMessage("Пароль должен содержать не менее одной цифры.");
                return false;
            }

            if (!tbEmail.Text.Contains("@") && !tbEmail.Text.Contains("."))
            {
                WarningMessage("Неверный формат почты.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
