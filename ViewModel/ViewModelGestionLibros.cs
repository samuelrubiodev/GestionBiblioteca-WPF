using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteca.ViewModel
{
    public class ViewModelGestionLibros : INotifyPropertyChanged
    {   
        private int _id;
        private string _titulo;
        private string _autor;
        private DateTime _fechaPublicacion;
        private string _genero;
        private string _isbn;

        private ObservableCollection<Libro> _libros;

        public ObservableCollection<Libro> Libros
        {
            get { return _libros; }
            set
            {
                if (value != _libros)
                {
                    _libros = value;
                    OnPropertyChanged(nameof(Libros));
                }
            }
        }

        public ViewModelGestionLibros()
        {
            _libros = new ObservableCollection<Libro>();
            Libros.Add(new Libro(1, "El Quijote", "Cervantes", new DateTime(1605, 1, 1), "Novela", "1234567890"));
        }

        public int ID
        {
            get { return _id; }
            set 
            { 
                _id = value; 
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }
        public string Autor
        {
            get { return _autor; }
            set 
            { 
                _autor = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set
            {
                _fechaPublicacion = value;
                OnPropertyChanged(nameof(FechaPublicacion));
            }
        }

        public string Genero
        {
            get { return _genero; }
            set
            {
                _genero = value;
                OnPropertyChanged(nameof(Genero));
            }
        }

        public string ISBN
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
