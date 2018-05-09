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
using ValeraCinema.util;

namespace ValeraCinema.Pages
{
    public partial class LogIn : Form
    {
        public InterFace1 films;

        private List<User> userList;

        public LogIn()
        {
            InitializeComponent();
            userList = new List<User>();
        }

        public LogIn(List<User> dataUsers)
        {
            InitializeComponent();
            userList = dataUsers;
        }


        public void CheckLogin(List<TextBox> txtList, List<User> dataUsers)
        {
            if (txtList.Count == 2)
            if (Util.CheckTextBoxes(txtList))
            {
                    User us = new User();
                    us.Nickname = log.Text;
                    us.Password = pass.Text;

                    if (us.Nickname == null)
                    {
                        DialogManager.showDialogError("Поле для ввода никнейма должно содержать 3-20 символов, состоять только из латинских букв, цифр и знака подчеркивания. Но не должен начинаться со знака подчеркивания", "");
                        return;
                    }

                    if (us.Password == null)
                    {
                        DialogManager.showDialogError("Поле для ввода пароля должно содержать 3-20 символов", "");
                        return;
                    }


                    foreach (User u in dataUsers)
                {
                    if (u.Nickname.Equals(txtList[0].Text) && u.Password.Equals(txtList[1].Text))
                    {
                        DialogManager.showDialogInfo("Успешный вход в личный кабинет", "");

                        User.getInstance().IdUser = u.IdUser;
                        User.getInstance().Name = u.Name;
                        User.getInstance().Nickname = u.Nickname;
                        User.getInstance().Password = u.Password;
                        User.getInstance().Phone = u.Phone;
                        User.getInstance().Role = u.Role;

                        Close();
                        return;
                    }
                }
                DialogManager.showDialogError("Пользователя с такими данными не существует. Проверьте введенные данные.", "");
            }
            else
            {
                DialogManager.showDialogError("Заполните все поля корректно", "");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin(new List<TextBox> { log, pass }, new FilmsContainer().Users.ToList());
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, new EventArgs());
            }
        }
    }
}
