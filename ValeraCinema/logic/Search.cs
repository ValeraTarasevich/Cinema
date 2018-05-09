using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValeraCinema.logic
{
    public class Search : ISearch
    {
        public List<Film> find(List<Film> data, string msg)
        {
            if (msg==null || msg.Equals(""))
            {
                return null;
            } else
            {
                if (data == null || data.Count == 0)
                {
                    return null;
                }
                else
                {
                    List<Film> result = new List<Film>();

                    foreach (Film f in data)
                    {
                        if (f.Name.Contains(msg) || f.Style.Contains(msg) || f.Country.Contains(msg) || f.Year.ToString().Contains(msg))
                        {
                            result.Add(f);
                        }
                    }
                    return result;
                }
            }

            
        }
    }
}
