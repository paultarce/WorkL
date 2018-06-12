using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new BoardAppMain());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sistem is overloaded.Close apps and make sure you have enough RAM free");
                MessageBox.Show("\n", ex.Message.ToString());
            
            }
        }
    }
}
