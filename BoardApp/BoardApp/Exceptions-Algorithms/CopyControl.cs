using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardApp.Exceptions_Algorithms
{
    public static class CopyControl
    {
        public static T Clone<T>(this T control) where T : PictureBox
        {
            T result = Activator.CreateInstance<T>();
            PropertyInfo[] piCollection = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piCollection)
            {
                if (pi.CanWrite)
                {
                    if(pi.Name != "WindowTarget")
                    {
                        pi.SetValue(result, pi.GetValue(control, null), null);
                    }
                }
                
            }
            return result;
        }
    }
}
