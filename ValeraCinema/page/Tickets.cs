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
            films = new FilmsContainer();
            film = f;
            commet.Text = "";

            info.Text = "Название: " + film.Name + Environment.NewLine;
            info.Text += "Жанр: " + film.Style + Environment.NewLine;
            info.Text += "Страна: " + film.Country + Environment.NewLine;
            info.Text += "Год:" + film.Year + Environment.NewLine;
            info.Text += "Цена: "+ film.Price + Environment.NewLine;
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
                Order o = new Order(User.getInstance().IdUser, film.IdFilm, commet.Text);
                films.Orders.Add(o);
                films.SaveChanges();
                
            }
            //Order o = new Order(commet.Text, User.getInstance(), Film);
            //o.IdOrder = 10;
            //if (!(commet.Text == ""))
            //{
            //    Order o = new Order();
            //    o.IdFilm = film.IdFilm;
            //    o.IdUser = User.getInstance().IdUser;
            //    o.Status = "New";
            //    o.Comment = commet.Text;
            //    //o.Comment = Convert.ToInt32(commet);

            //    if (o.Comment == null)
            //    {
            //        DialogManager.showDialogError("Поле для ввода информации должно содержать от 1 до 20 символов", "");
            //        return;
            //    }

            //    o.Film = film;
            //    o.User = User.getInstance();

            //    films.Orders.Add(o);
            //    //films.SaveChanges();


            //    try
            //    {
            //        films.SaveChanges();
            //    }
            //    catch (DbEntityValidationException ex)
            //    {
            //        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
            //        {
            //            Console.Write("Object: " + validationError.Entry.Entity.ToString());
            //            Console.Write(" ");
            //            foreach (DbValidationError err in validationError.ValidationErrors)
            //            {
            //                Console.Write(err.ErrorMessage + " ");
            //            }
            //        }
            //    }

            //    DialogManager.showDialogInfo("Успешный заказ!", "");
            //}
            //else
            //{
            //    DialogManager.showDialogError("Введите пожалуйста количество требуемых мест", "");
            //}
        }
    }
}
