using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity.Forms
{
    public partial class GuestForm : Form
    {
        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

        public GuestForm()
        {
            InitializeComponent();
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            LoadEvents();


            string logo = dgvEvents.Rows[0].Cells[4].Value.ToString();

            string defaultLogo = Path.Combine(projectDirectory, $"Resources\\Images\\eventsLogo\\defaultLogo.png");

            if (logo == "Отсутствует")
            {
                if (File.Exists(defaultLogo))
                {
                    pbLogo.ImageLocation = defaultLogo;
                }
            }
            else
            {
                string logoPath = Path.Combine(projectDirectory, $"Resources\\Images\\eventsLogo\\{logo}.png");

                if (File.Exists(logoPath))
                {
                    pbLogo.ImageLocation = logoPath;
                }
            }
        }

        private void LoadEvents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM EventsView", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvEvents.DataSource = dt;

                            dgvEvents.Columns["id"].Visible = false;
                            dgvEvents.Columns["Логотип мероприятия"].Visible = false;
                            dgvEvents.RowHeadersVisible = false;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Ошибка загрузки направлений: {sqlEx.Message}");
                ErrorMessage("Не удалось получить направления из представления.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                ErrorMessage("Произошла непредвиденная ошибка.");
            }
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void GuestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            chbDateFilter.Checked = false;
            Filter();
        }

        private void Filter()
        {

            DataTable dataTable = (DataTable)dgvEvents.DataSource;
            DataView dataView = dataTable.DefaultView;

            dataView.RowFilter = string.Empty;

            if (chbDateFilter.Checked)
            {
                DateTime dateFrom = dtpFrom.Value.Date;
                DateTime dateTo = dtpTo.Value.Date;

                string dateFilter = string.Format("[Дата начала] >= '{0}' AND [Дата окончания] <= '{1}'", dateFrom.ToString("yyyy-MM-dd"), dateTo.ToString("yyyy-MM-dd"));

                dataView.RowFilter = dateFilter;
            }

            dgvEvents.Refresh();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.MinDate = (DateTime)dtpFrom.Value;
            Filter();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.MaxDate = (DateTime)dtpTo.Value;
            Filter();
        }

        private void chbDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDateFilter.Checked == true)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }

            Filter();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                string logo = dgvEvents.CurrentRow.Cells[4].Value.ToString();

                string defaultLogo = Path.Combine(projectDirectory, $"Resources\\Images\\eventsLogo\\defaultLogo.png");

                if (logo == "Отсутствует")
                {
                    if (File.Exists(defaultLogo))
                    {
                        pbLogo.ImageLocation = defaultLogo;
                    }
                }
                else
                {
                    string logoPath = Path.Combine(projectDirectory, $"Resources\\Images\\eventsLogo\\{logo}.png");

                    if (File.Exists(logoPath))
                    {
                        pbLogo.ImageLocation = logoPath;
                    }
                }
            }
        }
    }
}
