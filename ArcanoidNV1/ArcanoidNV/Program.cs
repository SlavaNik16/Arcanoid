using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcanoidNV
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OsnovaForm osn = new OsnovaForm();
            MenuForm menu = new MenuForm();
            menu.Show();
            osn.Opacity = 0;
            Application.Run(osn);


        }
    }
}
