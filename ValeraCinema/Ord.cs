//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ValeraCinema
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ord
    {
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public int IdFilm { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

        public Ord()
        {
        }

        public Ord(int idOrder, string comment, string status, User user, Film film)
        {
            IdOrder = idOrder;

            IdUser = user.IdUser;
            IdFilm = film.IdFilm;

            Comment = comment;
            Status = status;
        }

        public Ord(string comment, string status, User user, Film film)
        {
            IdUser = user.IdUser;
            IdFilm = film.IdFilm;

            Comment = comment;
            Status = status;
        }

        public Ord(string comment, User user, Film film)
        {
            IdUser = user.IdUser;
            IdFilm = film.IdFilm;

            Comment = comment;
            Status = "New";
        }

        public Ord(int idOrder, string comment, User user, Film film)
        {
            IdOrder = idOrder;

            IdUser = user.IdUser;
            IdFilm = film.IdFilm;

            Comment = comment;
            Status = "New";
        }
    }
}
