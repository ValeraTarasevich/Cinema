using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValeraCinema.Pages
{
    public partial class Tickets : Form
    {
        FilmsContainer films;
        Film film;

        public Tickets(Film f, FilmsContainer _films)
        {
            InitializeComponent();
            films = _films;
            film = f;
            commet.Text = "";

            info.Text = "Название: " + film.Name + Environment.NewLine;
            info.Text += "Жанр: " + film.Style + Environment.NewLine;
            info.Text += "Страна: " + film.Country + Environment.NewLine;
            info.Text += "Год:" + film.Year + Environment.NewLine;
            info.Text += "Цена: " + film.Price + Environment.NewLine;
            info.Text += "--------------------------" + Environment.NewLine;
            info.Text += "Роль в системе: " + User.getInstance().Nickname + Environment.NewLine;
            info.Text += "Никнейм: " + User.getInstance().Nickname + Environment.NewLine;
            info.Text += "Телефон: " + User.getInstance().Phone + Environment.NewLine;


        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (commet.Text != "")
            {
                Ord o = new Ord(commet.Text, User.getInstance(), film);


                List<Ord> os = films.Ords.ToList();

                foreach (Ord ord in os)
                {
                    if ((ord.IdFilm == o.IdFilm) && (ord.IdUser == o.IdUser))
                    {
                        DialogManager.showDialogError("У вас уже имеется заказ на этот фильм!", "");
                        return;
                    }
                }
                

                films.Ords.Add(o);
                films.SaveChanges();

                DialogManager.showDialogInfo("Успешный заказ!", "");
            }            
            else
            {
                DialogManager.showDialogError("Введите пожалуйста количество требуемых мест", "");
            }
     
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            if (User.getInstance().IdUser == 0)
            {
                DialogManager.showDialogError("Нужно зарегистрироваться или авторизоваться","");
                Close();
            }
        }
    }
}
