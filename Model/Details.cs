using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZTaskManager.Model
{
    class Details : INotifyPropertyChanged
    {
        private string name = string.Empty;
        public string Name { get => name; set => Set(ref name, value); }

        private int pID = 0;
        public int PID { get => pID; set => Set(ref pID, value); }

        private string status = string.Empty;
        public string Status { get => status; set => Set(ref status, value); }

        private string userName = string.Empty;
        public string UserName { get => userName; set => Set(ref userName, value); }

        private string cPU = string.Empty;
        public string CPU { get => cPU; set => Set(ref cPU, value); }

        private string memory = string.Empty;
        public string Memory { get => memory; set => Set(ref memory, value); }

        private string description = string.Empty;
        public string Description { get => description; set => Set(ref description, value); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
