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

        private void Orders_Load(object sender, EventArgs e)
        {
            films = new FilmsContainer();

            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = films.Orders.Count()+1;

            int row = 0;
            dataGridView1.Rows[row].Cells[0].Value = "Name";
            dataGridView1.Rows[row].Cells[1].Value = "Phone";
            dataGridView1.Rows[row].Cells[2].Value = "Name";
            dataGridView1.Rows[row].Cells[3].Value = "Status";
            dataGridView1.Rows[row].Cells[4].Value = "id";

            List<User> us = films.Users.ToList();
            List<Film> fs = films.Films1.ToList();

            foreach (Order ord in films.Orders)
            {
                row++;
                User u = us.FindLast(x => x.IdUser == ord.IdUser);
                Film f = fs.FindLast(x => x.IdFilm == ord.IdFilm);
                dataGridView1.Rows[row].Cells[0].Value = u.Name;
                dataGridView1.Rows[row].Cells[1].Value = u.Phone;
                dataGridView1.Rows[row].Cells[2].Value = f.Name;
                dataGridView1.Rows[row].Cells[3].Value = ord.Status;
                dataGridView1.Rows[row].Cells[4].Value = ord.IdOrder;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && !textBox1.Text.Equals(""))
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value);

                var order = films.Orders.Where(x => x.IdOrder == id).First(); 

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
