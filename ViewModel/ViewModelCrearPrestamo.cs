using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows;
using Biblioteca.View;

namespace Biblioteca.ViewModel
{
    public class ViewModelCrearPrestamo : INotifyPropertyChanged
    {
        private Window _window;
        private int _id { get; set; }
        private Libro _libro { get; set; }
        private Usuario _usuario { get; set; }
        private DateTime fechaPrestamo { get; set; }
        private DateTime fechaDevolucion { get; set; }

        private Libro _libroSeleccionado { get; set; }
        private Usuario _usuarioSeleccionado { get; set; }

        private ObservableCollection<Libro> _libros = new ObservableCollection<Libro>();
        private ObservableCollection<Usuario> _usuarios = new ObservableCollection<Usuario>();

        public event EventHandler<Prestamo> PrestamoCreado;

        public ICommand CrearPrestamo { get; set; }
        public ICommand Cancelar { get; set; }

        public ObservableCollection<Libro> Libros
        {
            get { return _libros; }
            set
            {
                _libros = value;
                OnPropertyChanged(nameof(Libros));
            }
        }


        public ObservableCollection<Usuario> Usuarios
        {
            get { return _usuarios; }
            set
            {
                _usuarios = value;
                OnPropertyChanged(nameof(Usuarios));
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

        public Usuario UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set
            {
                _usuarioSeleccionado = value;
                OnPropertyChanged(nameof(UsuarioSeleccionado));
            }
        }

        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set
            {
                fechaPrestamo = value;
                OnPropertyChanged(nameof(FechaPrestamo));
            }
        }

        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set
            {
                fechaDevolucion = value;
                OnPropertyChanged(nameof(FechaDevolucion));
            }
        }

        public ViewModelCrearPrestamo(Window window)
        {
            _window = window;
            Libros = new ObservableCollection<Libro>();
            Usuarios = new ObservableCollection<Usuario>();
            consultarLibros();
            consultarUsuarios();

            CrearPrestamo = new RelayCommand(crearPrestamo);
            Cancelar = new RelayCommand(cancelar);
        }

        public void consultarLibros()
        {
            modeloBBDD bd = new modeloBBDD();
            List<Libro> libros = bd.consultarLibros();
            foreach (Libro libro in libros)
            {
                Libros.Add(libro);
            }
        }
        
        public void consultarUsuarios()
        {
            modeloBBDD bd = new modeloBBDD();
            List<Usuario> usuarios = bd.consultarUsuarios();
            foreach (Usuario usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }
        }
        public void crearPrestamo()
        {
            Prestamo prestamo = new Prestamo(LibroSeleccionado, UsuarioSeleccionado, FechaPrestamo, FechaDevolucion);
            modeloBBDD bd = new modeloBBDD();
            int id = bd.insertarPrestamo(prestamo);
            prestamo.ID = id;
            PrestamoCreado?.Invoke(this, prestamo);
            _window.Close();
        }

        public void cancelar()
        {
            _window.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
