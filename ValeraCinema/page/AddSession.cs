using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValeraCinema.util;

namespace ValeraCinema.Pages
{
    public partial class AddSession : Form
    {
        FilmsContainer films;

        public AddSession()
        {
            InitializeComponent();
            films = new FilmsContainer();
        }

        private bool IsNumber(string txt)
        {
            try
            {
                int a = Convert.ToInt32(txt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsDouble(string txt)
        {
            try
            {
                double a = Convert.ToDouble(txt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Film filmValid(List<TextBox> txtList, List<DateTimePicker> dateList, List<Film> data)
        {
            if (txtList.Count == 7 && dateList.Count == 2) 
            if (Util.CheckDates(dateList) && Util.CheckTextBoxes(txtList))
            {
                Film f = new Film();
                f.Name = txtList[0].Text;
                f.Description = txtList[1].Text;
                f.Country = txtList[2].Text;
                f.Style = txtList[3].Text;
                f.Year = Convert.ToInt32(txtList[4].Text);
                f.Rating = Convert.ToDouble(txtList[5].Text);
                f.Price = Convert.ToDouble(txtList[6].Text);
                f.StartRental = dateList[0].Value;
                f.FinishRental = dateList[1].Value;

                    if (f.Name == null)
                    {
                        DialogManager.showDialogError("Поле для ввода названия фильма должно содержать 3-30 символов", "");
                        return null;
                    }
                    if (f.Year == 0)
                    {
                        DialogManager.showDialogError("Поле для ввода года выхода фильма должно содержать 4 числовых символа, больше 1888 и меньше текущего года", "");
                        return null;
                    }
                    if (f.Style == null)
                    {
                        DialogManager.showDialogError("Поле для ввода жанра фильма должно содержать только 3-20 буквенных символа", "");
                        return null;
                    }
                    if (f.Country == null)
                    {
                        DialogManager.showDialogError("Поле для ввода страны выхода фильма должно содержать только 3-20 буквенных символов", "");
                        return null;
                    }
                    if (f.Rating == 0)
                    {
                        DialogManager.showDialogError("Поле для ввода рейтинга должно содержать значение от 0.1 до 10", "");
                        return null;
                    }
                    if (f.Price == 0)
                    {
                        DialogManager.showDialogError("Поле для ввода цены должно содержать значение от 1 до 20", "");
                        return null;
                    }
                    if (f.Description == null)
                    {
                        DialogManager.showDialogError("Поле для ввода описания фильма должно содержать 5-100 символов", "");
                        return null;
                    }

                    if (f.StartRental > f.FinishRental)
                    {
                        DialogManager.showDialogError("Поле для ввода начальной даты показа должно быть раньше, чем поле окончания показа", "");
                        return null;
                    }


                    foreach (Film film in data)
                {
                    if (f.Equals(film))
                    {
                        DialogManager.showDialogError("Фильм с таким названием уже есть в БД", "");
                        return null;
                    }
                }
                return f;
            }
            else
            {
                DialogManager.showDialogError("Заполните все поля корректно", "");
                return null;
            } else
            {
                return null;
            }

        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            Film film = filmValid(new List<TextBox> { name_film, description, country, style, year, rating, price }, new List<DateTimePicker> { dateStart, dateEnd }, films.Films1.ToList());
            if (film != null)
            {
                films.Films1.Add(film);
                films.SaveChanges();
                DialogManager.showDialogInfo("Фильм уcпешно добавлен в БД", "");
                Close();
            }
        }
    }
}