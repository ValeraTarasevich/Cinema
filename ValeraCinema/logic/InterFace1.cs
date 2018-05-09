using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValeraCinema.logic
{
    public interface InterFace1
    {
        List<User> GetUsers { get; }
        int Save();
    }
}
