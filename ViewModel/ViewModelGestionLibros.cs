using Biblioteca.Model;
using Biblioteca.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteca.ViewModel
{
    public class ViewModelGestionLibros : INotifyPropertyChanged
    {
        private Window _window;

        private int _id;
        private string _titulo;
        private string _autor;
        private int _fechaPublicacion;
        private string _genero;
        private string _isbn;

        private Libro _libroSeleccionado;

        private ObservableCollection<Libro> _libros = new ObservableCollection<Libro>();

        public ICommand CrearLibro { get; set; }
        public ICommand EliminarLibro { get; set; }

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

        public ViewModelGestionLibros(Window window)
        {
            _window = window;

            anadirLibros();
            CrearLibro = new RelayCommand(crearLibro);
            EliminarLibro = new RelayCommand(eliminarLibro);
        }

        public void crearLibro()
        {
            CrearLibros crearLibros = new CrearLibros();
            ViewModelCrearLibros viewModelCrearLibros = (ViewModelCrearLibros)crearLibros.DataContext;
            viewModelCrearLibros.LibroCreado += OnLibroCreado;
            crearLibros.Show();
        }

        private void OnLibroCreado(object sender, Libro nuevoLibro)
        {
            Libros.Add(nuevoLibro);
        }

        public void anadirLibros()
        {
            try
            {
                modeloBBDD modeloBBDD = new modeloBBDD();
                List<Libro> libros = modeloBBDD.consultarLibros();

                System.Diagnostics.Debug.WriteLine($"Libros recuperados: {libros?.Count ?? 0}");

                Libros.Clear();
                if (libros != null && libros.Any())
                {
                    foreach (Libro libro in libros)
                    {
                        System.Diagnostics.Debug.WriteLine($"Libro: {libro.titulo} - {libro.autor}");
                        Libros.Add(libro);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar libros: {ex.Message}");
            }
        }

        public void eliminarLibro()
        {
            if (LibroSeleccionado != null)
            {
                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el libro '{LibroSeleccionado.titulo}'?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    modeloBBDD modeloBBDD = new modeloBBDD();
                    modeloBBDD.eliminarLibro(LibroSeleccionado);
                    Libros.Remove(LibroSeleccionado);
                    LibroSeleccionado = null;
                }
            }
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

        public Libro LibroSeleccionado
        {
            get { return _libroSeleccionado; }
            set
            {
                _libroSeleccionado = value;
                OnPropertyChanged(nameof(LibroSeleccionado));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
