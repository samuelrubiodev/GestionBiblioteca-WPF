using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ViewModel
{
    public class ViewModelGestionPrestamos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    
        public ViewModelGestionPrestamos()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
