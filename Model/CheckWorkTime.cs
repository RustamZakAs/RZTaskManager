using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZTaskManager.Model
{
    public static class CheckWorkTime
    {
        public static object Check(Action action, bool save = true)
        {
            if (!save)
            {
                DateTime start = DateTime.Now;
                action();
                return (DateTime.Now - start);
            }
            else
            {
                DateTime start = DateTime.Now;
                action();
                TimeSpan ts = (DateTime.Now - start);

                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\TT.txt";

                string txt;
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(File.OpenRead(path)))
                    {
                        txt = sr.ReadToEnd();
                    }
                    txt += "\n" + ts.ToString();
                }
                else txt = ts.ToString();

                File.WriteAllText(path, txt, Encoding.UTF8);

                return ts;
            }
        }
    }
}
