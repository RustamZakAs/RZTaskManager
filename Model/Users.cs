using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZTaskManager.Model
{
    class Users : INotifyPropertyChanged
    {
        private string user = string.Empty;
        public string User { get => user; set => Set(ref user, value); }

        private string status = string.Empty;
        public string Status { get => status; set => Set(ref status, value); }

        private double cPU = 0.00;
        public double CPU { get => cPU; set => Set(ref cPU, value); }

        private double memory = 0.00;
        public double Memory { get => memory; set => Set(ref memory, value); }

        private double disk = 0.00;
        public double Disk { get => disk; set => Set(ref disk, value); }

        private double network = 0.00;
        public double Network { get => network; set => Set(ref network, value); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
