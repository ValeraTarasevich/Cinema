using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValeraCinema
{
    class DialogManager
    {
        public static void showDialogError(String text, String header)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void showDialogInfo(String text, String header)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool showDialogYesNo(String text, String header)
        {
            if (MessageBox.Show(text, header, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                return true;
            else return false;

        }
    }

}

