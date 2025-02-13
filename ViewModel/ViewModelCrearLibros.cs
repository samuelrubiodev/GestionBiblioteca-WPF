using Biblioteca.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteca.ViewModel
{
    public class ViewModelCrearLibros : INotifyPropertyChanged
    {
        private int _id;
        private string _titulo;
        private string _autor;
        private int _fechaPublicacion;
        private string _genero;
        private string _isbn;

        public event EventHandler<Libro> LibroCreado;

        private Window _window;

        public ICommand CrearLibro { get; set; }
        public ICommand Cancelar { get; set; }
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

        public int AnioPublicacion
        {
            get { return _fechaPublicacion; }
            set
            {
                _fechaPublicacion = value;
                OnPropertyChanged(nameof(AnioPublicacion));
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

        public ViewModelCrearLibros(Window window)
        {
            _window = window;
            CrearLibro = new RelayCommand(crearLibro);
            Cancelar = new RelayCommand(cancelar);
        }

        public bool PuedeCrearLibro()
        {
            return !string.IsNullOrWhiteSpace(Titulo) &&
                   !string.IsNullOrWhiteSpace(Autor) &&
                   AnioPublicacion > 0 &&
                   !string.IsNullOrWhiteSpace(Genero) &&
                   !string.IsNullOrWhiteSpace(ISBN);
        }


        public void crearLibro()
        {
            modeloBBDD modeloBBDD = new modeloBBDD();
            Libro libro = new Libro(Titulo,Autor,AnioPublicacion,Genero,ISBN);
            modeloBBDD.insertarLibros(libro);
            LibroCreado?.Invoke(this, libro);
        }

        public void cancelar()
        {
            _window.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
