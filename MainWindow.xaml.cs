using RZTaskManager.View;
using RZTaskManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RZTaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = MainViewModel;

            MessageBox.Show(((TimeSpan)CheckWorkDate(sleepWork,true)).ToString());

            if (false)
            {
                //Process.Start("notepad");
                //Process.Start("Text.txt");
                //Process.Start("chrome", "https://facebook.com");
                //Process.Start("notepad++", "Text.txt");
                Process[] processes = Process.GetProcesses();
                List<Process> processesList = new List<Process>();
                processesList.AddRange(processes);
                string str = string.Empty;
                foreach (Process item in processes)
                {
                    try
                    {
                        str += item.Id.ToString() + " " + item.ProcessName.ToString() + " " + item.PriorityClass.ToString() + " \\ ";
                    }
                    catch (Exception) { }
                }
                MessageBox.Show(str);
            }
        }

        private object CheckWorkDate(Action action, bool save = true)
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

        private void sleepWork()
        {
            Thread.Sleep(2000);
        }
    }
}
