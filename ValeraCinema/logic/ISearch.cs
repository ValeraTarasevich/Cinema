using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValeraCinema.logic
{
    public interface ISearch
    {
        List<Film> find(List<Film> data, String msg);

    }
}
