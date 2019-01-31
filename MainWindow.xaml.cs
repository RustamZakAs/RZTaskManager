using RZTaskManager.Model;
using RZTaskManager.View;
using RZTaskManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            //MessageBox.Show(((TimeSpan)CheckWorkTime.Check(sleepWork,true)).ToString());
            ObservableCollection<Detail> Details = new ObservableCollection<Detail>();
            if (true)
            {
                //Process.Start("notepad");
                //Process.Start("Text.txt");
                //Process.Start("chrome", "https://facebook.com");
                //Process.Start("notepad++", "Text.txt");
                Process[] processes = Process.GetProcesses();
                //List<Process> processesList = new List<Process>();
                //processesList.AddRange(processes);
                string str = string.Empty;
                foreach (Process item in processes)
                {
                    try
                    {
                        str += item.Id.ToString() + " " + 
                               item.SessionId.ToString() + " " + 
                               item.ProcessName.ToString() + " " + 
                               item.PriorityClass.ToString() + " \\ ";
                        Detail detail = new Detail();
                        detail.Name = item.ProcessName;
                        detail.PID = item.Id;
                        detail.Status = "Running";
                        detail.UserName = item.MachineName;
                        detail.Memory = ((double)(item.PagedMemorySize64 / 1024)).ToString();
                        Details.Add(detail);
                    }
                    catch (Exception) { }
                }
                MessageBox.Show(str);
            }
        }

        private void sleepWork()
        {
            Thread.Sleep(2000);
        }
    }
}
