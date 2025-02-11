using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteca.ViewModel
{
    public class ViewModelGestionBiblioteca : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand InsertarLibrosCommand { get; set; }

        public ViewModelGestionBiblioteca()
        {
            InsertarLibrosCommand = new RelayCommand(InsertarLibros);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertarLibros()
        {

        }
    }
}
