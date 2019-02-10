using RZTaskManager.Model;
using RZTaskManager.View;
using RZTaskManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string text = "Details";
        public string Text { get => text; set => Set(ref text, value); }

        private ObservableCollection<Detail> details;
        public ObservableCollection<Detail> Details { get => details; set => Set(ref details, value); }

        ObservableCollection<Detail> Users = new ObservableCollection<Detail>();

        private Detail selectedDetail;
        public Detail SelectedDetail { get => selectedDetail; set => Set(ref selectedDetail, value); }

        public MainWindow()
        {
            InitializeComponent();
            Details = new ObservableCollection<Detail>();
            DataContext = this;

            //MessageBox.Show(((TimeSpan)CheckWorkTime.Check(sleepWork,true)).ToString());
            
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
            //MessageBox.Show(str);
            MessageBox.Show(Details[0].Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
