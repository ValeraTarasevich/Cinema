using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValeraCinema
{
    public partial class Orders : Form
    {
        FilmsContainer films;

        public Orders()
        {
            InitializeComponent();
        }

        private void CreateHeaderTable(DataGridView dgv)
        {
            dgv.Columns.Clear();
       
            dgv.Columns.Add("User Name", "User Name");
            dgv.Columns.Add("Phone", "Phone");
            dgv.Columns.Add("Film Name", "Film Name");
            dgv.Columns.Add("Status", "Status");
            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("Count Tickets", "Count Tickets");
        }

        private void LoadTable(DataGridView dgv, List<Ord> data)
        {
            dgv.Rows.Clear();
            if (data == null || data.Count == 0)
            {
                dgv.RowCount = 1;
                DialogManager.showDialogError("Ничего не найденно по данным критериям", "");
            }
            else
            {
                dgv.RowCount = data.Count;
            }

            int row = -1;   

            List<User> us = films.Users.ToList();
            List<Film> fs = films.Films1.ToList();

            foreach (Ord ord in data)
            {
                row++;
                User u = us.FindLast(x => x.IdUser == ord.IdUser);
                Film f = fs.FindLast(x => x.IdFilm == ord.IdFilm);
                dataGridView1.Rows[row].Cells[0].Value = u.Name;
                dataGridView1.Rows[row].Cells[1].Value = u.Phone;
                dataGridView1.Rows[row].Cells[2].Value = f.Name;
                dataGridView1.Rows[row].Cells[3].Value = ord.Status;
                dataGridView1.Rows[row].Cells[4].Value = ord.IdOrder;
                dataGridView1.Rows[row].Cells[5].Value = ord.Comment;
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            

            films = new FilmsContainer();

            CreateHeaderTable(dataGridView1);
            LoadTable(dataGridView1, films.Ords.ToList());

            //dataGridView1.ColumnCount = 5;
            //dataGridView1.RowCount = films.Orders.Count()+1;

            //int row = 0;
            //dataGridView1.Rows[row].Cells[0].Value = "Name";
            //dataGridView1.Rows[row].Cells[1].Value = "Phone";
            //dataGridView1.Rows[row].Cells[2].Value = "Name";
            //dataGridView1.Rows[row].Cells[3].Value = "Status";
            //dataGridView1.Rows[row].Cells[4].Value = "id";

            //List<User> us = films.Users.ToList();
            //List<Film> fs = films.Films1.ToList();

            //foreach (Ord ord in films.Ords)
            //{
            //    row++;
            //    User u = us.FindLast(x => x.IdUser == ord.IdUser);
            //    Film f = fs.FindLast(x => x.IdFilm == ord.IdFilm);
            //    dataGridView1.Rows[row].Cells[0].Value = u.Name;
            //    dataGridView1.Rows[row].Cells[1].Value = u.Phone;
            //    dataGridView1.Rows[row].Cells[2].Value = f.Name;
            //    dataGridView1.Rows[row].Cells[3].Value = ord.Status;
            //    dataGridView1.Rows[row].Cells[4].Value = ord.IdOrder;
            //}      
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && !textBox1.Text.Equals(""))
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value);

                var order = films.Ords.Where(x => x.IdOrder == id).First(); 

                if (order != null)
                {
                    order.Status = textBox1.Text;
                    films.SaveChanges();
                }
            }
            Orders_Load(sender,e);
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
