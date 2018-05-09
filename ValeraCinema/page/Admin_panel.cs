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

namespace ValeraCinema.Pages
{
    public partial class Admin_panel : Form
    {
        public FilmsContainer films;

        public Admin_panel()
        {
            InitializeComponent();
            films = new FilmsContainer();
        }

        private void Admin_panel_Load(object sender, EventArgs e)
        {
            films = new FilmsContainer();

            List<User> all = films.Users.ToList() ;

            List<User> notModer = all.FindAll(x => x.Role.Equals(UserRole.User.ToString()));

            List<User> moder = all.FindAll(x => x.Role.Equals(UserRole.Moder.ToString()));

            all_users.DataSource = notModer;

            all_operators.DataSource = moder;

        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsEmpty(string str)
        {
            if (str == null || str.Equals(""))
            {
                return true;
            }

            return false;
        }

        

        public User getById(int id)
        {
            return films.Users.ToList().FirstOrDefault(x => x.IdUser == id);
        }

        public bool changeRoleUM(string str)
        {
            if (!IsEmpty(str))
            {
                int id = Convert.ToInt32(str);


                var user = getById(id); //metod for mock

                if (user != null)
                {
                    user.Role = UserRole.Moder.ToString();
                    films.SaveChanges();
                    DialogManager.showDialogInfo("Успешное назначение оператора", "");
                    return true;
                }
                return false;
            } else
            {
                return false;
            }
        }

        public void btnSetOperater_Click(object sender, EventArgs e)
        {
            int row = all_users.SelectedCells[0].RowIndex;
            bool f = changeRoleUM(all_users.Rows[row].Cells[0].Value.ToString());
            if (f)
            {
                Admin_panel_Load(sender, e);
            } else
            {
                DialogManager.showDialogError("Error", "");
            }
            
        }
//дописать хуйню на проверку ячейки
        private void btnDelOperater_Click(object sender, EventArgs e)
        {
            if (true)
            {
                int row = all_operators.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(all_operators.Rows[row].Cells[0].Value);

                var user = films.Users.ToList().Where(x => x.IdUser == id).First();

                if (user != null)
                {
                    user.Role = UserRole.User.ToString();
                    films.SaveChanges();
                    DialogManager.showDialogInfo("Успешное изменение роли с оператора на пользователя", "");
                }
            }
            Admin_panel_Load(sender, e);
        }
    }
}
