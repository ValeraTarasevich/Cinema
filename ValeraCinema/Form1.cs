using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValeraCinema.logic;
using ValeraCinema.Pages;

namespace ValeraCinema
{
    public partial class Form1 : Form
    {
        FilmsContainer films;
        List<Film> current;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showButtons();
            films = new FilmsContainer();
            current = films.Films1.ToList().FindAll(x => (x.FinishRental >= DateTime.Now));
            CreateHeaderTable(dataGridView1);
            LoadTable(dataGridView1, current);
        }

        private void CreateHeaderTable(DataGridView dgv)
        {
            dgv.Columns.Clear();

            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("Name", "Name");
            dgv.Columns.Add("Country", "Country");
            dgv.Columns.Add("Style", "Style");
            dgv.Columns.Add("Year", "Year");
            dgv.Columns.Add("Rating", "Rating");
            dgv.Columns.Add("Price", "Price");
        }

        private void LoadTable(DataGridView dgv, List<Film> data)
        {
            dgv.Rows.Clear();
            if (data == null || data.Count == 0)
            {
                dgv.RowCount = 1;
                DialogManager.showDialogError("Действующиих сеансов не обнаружено", "");
            }
            else
            {
                dgv.RowCount = data.Count;
            }
            int row = -1;
            //dataGridView1.RowCount = data.Count + 1;

            foreach (Film f in data)
            {
                row++;
                dgv.Rows[row].Cells[0].Value = f.IdFilm;
                dgv.Rows[row].Cells[1].Value = f.Name;
                dgv.Rows[row].Cells[2].Value = f.Country;
                dgv.Rows[row].Cells[3].Value = f.Style;
                dgv.Rows[row].Cells[4].Value = f.Year;
                dgv.Rows[row].Cells[5].Value = f.Rating;
                dgv.Rows[row].Cells[6].Value = f.Price;
            }
        }
        private void showButtons()
        {
            if (User.getInstance().Nickname == null || User.getInstance().Nickname.Equals(""))
            {
                btnAddFilm.Hide();
                btnExit.Hide();
                btnShowOrders.Hide();
                btnChangeRole.Hide();
                btnShowAllFilms.Hide();
                btnDeleteFilm.Hide();

                btnAddOrder.Show();
                btnNowFilm.Show();
                btnLogIn.Show();
                btnSignIn.Show();
            }
            else
            {
                if (User.getInstance().Role.Equals(UserRole.Administration.ToString()))
                {
                    btnExit.Show();
                    btnShowOrders.Show();
                    btnChangeRole.Show();
                    btnShowAllFilms.Show();
                    btnNowFilm.Show();

                    btnDeleteFilm.Hide();
                    btnAddFilm.Hide();
                    btnAddOrder.Hide();
                    btnLogIn.Hide();
                    btnSignIn.Hide();
                }
                else
                {
                    if (User.getInstance().Role.Equals(UserRole.Moder.ToString()))
                    {
                        btnAddFilm.Show();
                        btnExit.Show();
                        btnShowOrders.Show();
                        btnShowAllFilms.Show();
                        btnNowFilm.Show();
                        btnDeleteFilm.Show();

                        btnAddOrder.Hide();
                        btnChangeRole.Hide();
                        btnLogIn.Hide();
                        btnSignIn.Hide();
                    }
                    else
                    {
                        if (User.getInstance().Role.Equals(UserRole.User.ToString()))
                        {
                            btnAddOrder.Show();
                            btnExit.Show();
                            btnNowFilm.Show();

                            btnShowAllFilms.Hide();
                            btnDeleteFilm.Hide();
                            btnShowOrders.Hide();
                            btnChangeRole.Hide();
                            btnAddFilm.Hide();
                            btnLogIn.Hide();
                            btnSignIn.Hide();
                        }
                        else
                        {
                            User.delInstance();
                            DialogManager.showDialogError("User error", "");
                            btnAddFilm.Hide();
                            btnAddOrder.Hide();
                            btnExit.Hide();
                            btnShowOrders.Hide();
                            btnChangeRole.Hide();
                            btnNowFilm.Hide();
                            btnShowAllFilms.Hide();
                            btnDeleteFilm.Hide();

                            btnLogIn.Show();
                            btnSignIn.Show();
                        }

                    }
                }

            }

        }


        private bool IsSelected()
        {
            try
            {
                return true;
            } catch (Exception ex)
            {
                return false;
            }
            
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {

            if (IsSelected())
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);

                var f = films.Films1.Where(x => x.IdFilm == id).First();

                if (f != null)
                {
                    Tickets t = new Tickets(f, films);
                    t.ShowDialog();

                    t.Close();
                } else
                {
                    DialogManager.showDialogInfo("На данный момент нет действующих сеансов, приносим свои извинения.", "");
                }
            } else
            {
                DialogManager.showDialogInfo("Выберите фильм","");
            }

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.ShowDialog();
            if (User.getInstance().Nickname != null)
            {
                label2.Text = "И снова здравствуйте, " + User.getInstance().Nickname;
            }
            li.Close();
            showButtons();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.ShowDialog();
            if (User.getInstance().Nickname != null)
            {
                label2.Text = "Добро пожаловать, " + User.getInstance().Nickname;
            }

            si.Close();
            showButtons();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            User.delInstance();
            label2.Text = "";
            showButtons();
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            AddSession f = new AddSession();
            f.ShowDialog();

            f.Close();
            films = new FilmsContainer();
            current = films.Films1.ToList().FindAll(x => (x.FinishRental >= DateTime.Now));
            LoadTable(dataGridView1, current);
        }

        private void btnShowAllFilms_Click(object sender, EventArgs e)
        {
            LoadTable(dataGridView1, films.Films1.ToList());
        }

        private void btnShowOrders_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.ShowDialog();

            orders.Close();
            
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            ap.ShowDialog();

            ap.Close();
        }

        private void btnNowFilm_Click(object sender, EventArgs e)
        {
            LoadTable(dataGridView1, current);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ISearch search = new Search();
            if (!(SearchBox.Text == ""))
            {
                LoadTable(dataGridView1, search.find(current, SearchBox.Text));
            }
            else
            {
                DialogManager.showDialogError("Строка поиска пуста. Введите информацию в строку", "");
            }
        }

        //доработать, не удаляет последний фильм
        private void btnDeleteFilm_Click(object sender, EventArgs e)
        {

           
            if (IsSelected())
            {
                var row = dataGridView1.CurrentRow;
                int id = (int)row.Cells["Id"].Value;
                var film = films.Films1.FirstOrDefault(x => x.IdFilm == id);

                if (MessageBox.Show("Вы уверены, что хотите удалить фильм?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    DialogManager.showDialogInfo("Фильм успешно удален", "");
                    if (film != null)
                    {
                        films.Films1.Remove(film);
                    }
                    films.SaveChanges();
                }
                else
                {
                    return;
                }
            }
            else
            {
                DialogManager.showDialogError("Выберите фильм", "");
            }
            //LoadTable(dataGridView1, films.Films1.ToList());
        }
    }
}
