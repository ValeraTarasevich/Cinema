using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValeraCinema.util
{
    public class Util
    {
        public static bool CheckTextBoxes(List<TextBox> list)
        {
            foreach (TextBox txt in list)
            {
                if (txt == null || txt.Text.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckDates(List<DateTimePicker> list)
        {
            foreach (DateTimePicker date in list)
            {
                //    if (date.Value == null)
                //    {
                //        return false;
                //    }
            }
            return true;
        }
    }
}
