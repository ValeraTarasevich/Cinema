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
    using System.Text.RegularExpressions;

    enum UserRole
    {
        Administration, Moder, User
    }

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        private string _password;
        private string _name;
        private string _nickname;
        private string _phone;

        string pattern = @"^[a-zA-Z][a-zA-Z0-9-_\.]{2,20}$";
        string pattern_phone = @"^[0-9]{2}[0-9]{3}[0-9]{4}$";

        public User()
        {
            this.Orders = new HashSet<Order>();
            Role = UserRole.User.ToString();
        }

        private static User user;
        private static Boolean block = false;


        public int IdUser { get; set; }
        public string Name { get { return _name; } set { if (isPasswordInRange(value, 2, 30)) { _name = value; } } }
        public string Phone { get { return _phone; } set { if (isPhone(value)) { _phone = value; } } }
        public string Role { get; set; }
        public string Nickname { get { return _nickname; } set { if (isNickname(value)) { _nickname = value; } } }
        public string Password
        {
            get { return _password; }
            set
            {
                if (isPasswordInRange(value, 3, 20))
                {
                    _password = value;
                }
            }
        }

        public bool isPasswordInRange(string value, int min, int max)
        {
            return value.Length >= min && value.Length <= max;
        }
        public bool isNickname(string value)
        {
            return Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
        }

        public bool isPhone(string value)
        {
            return Regex.IsMatch(value, pattern_phone, RegexOptions.IgnoreCase);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public static User getInstance()
        {
            try
            {
                block = true;
                if (user == null)
                {
                    user = new User();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                block = false;
            }
            return user;
        }

        public static void delInstance()
        {
            try
            {
                block = true;
                if (user != null)
                {
                    user = null;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                block = false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (Nickname != null)
                {
                    User f = obj as User;
                    if (Nickname.Equals(f.Nickname))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }


            }
        }

    }
}