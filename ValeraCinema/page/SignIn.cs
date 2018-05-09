using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValeraCinema.Pages
{
    public partial class SignIn : Form
    {
        FilmsContainer films;
        
        public SignIn()
        {
            InitializeComponent();
        }

        private bool IsEmptyFields()
        {
            if (name.Text.Equals("") || name == null)
            {
                return true;
            }

            if (password.Text.Equals("") || password == null)
            {
                return true;
            }

            if (rep_password.Text.Equals("") || rep_password == null)
            {
                return true;
            }

            if (phone.Text.Equals("") || phone == null)
            {
                return true;
            }

            if (login.Text.Equals("") || login == null)
            {
                return true;
            }

            return false;
        }
        private void bynCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!IsEmptyFields())
            {
                if (password.Text.Equals(rep_password.Text))
                {
                    User user = new User();


                    user.Name = name.Text;
                    user.Nickname = login.Text;
                    user.Password = password.Text;
                    user.Phone = phone.Text;
                    user.Role = UserRole.User.ToString();

                    if (user.Name == null)
                    {
                        DialogManager.showDialogError("Поле для ввода имени и фамилии должно содержать 2-30 символов", "");
                        return;
                    }

                    if (user.Nickname == null)
                    {
                        DialogManager.showDialogError("Поле для ввода никнейма должно содержать 3-20 символов, состоять только из латинских букв, цифр и знака подчеркивания.", "");
                        return;
                    }

                    if (user.Phone == null)
                    {
                        DialogManager.showDialogError("Поле для ввода телефона должно содержать 9 цифровых символов", "");
                        return;
                    }

                    if (user.Password == null)
                    {
                        DialogManager.showDialogError("Поле для ввода пароля должно содержать 3-20 символов", "");
                        return;
                    }

                    films = new FilmsContainer();

                    foreach (User us in films.Users)
                    {
                        if (us.Equals(user))
                        {
                            DialogManager.showDialogError("Пользователь с данным никнеймом уже существует!", "");
                            return;
                        }
                    }
                    films.Users.Add(user);
                    films.SaveChanges();

                    User.getInstance().IdUser = user.IdUser;
                    User.getInstance().Name = user.Name;
                    User.getInstance().Nickname = user.Nickname;
                    User.getInstance().Password = user.Password;
                    User.getInstance().Phone = user.Phone;
                    User.getInstance().Role = user.Role;

                    DialogManager.showDialogInfo("Успешная регистрация!", "");
                    Close();
                }
                else
                {
                    DialogManager.showDialogError("Пароли не совпадают!", "");
                    return;
                }
            }
            else
            {
                DialogManager.showDialogError("Заполните все поля!", "");
                return;
            }
        }
    }
}
