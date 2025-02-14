using Biblioteca.Model;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class ViewModelCrearUsuario : INotifyPropertyChanged
    {
        private Window _window;
        private string _nombre { get; set; }
        private string _apellido { get; set; }
        private string _email { get; set; }
        private string _contrasena { get; set; }
        private string _telefono { get; set; }
        private string _rol { get; set; }

        public ICommand CrearUsuario { get; set; }
        public ICommand Cancelar { get; set; }

        public event EventHandler<Usuario> UsuarioCreado;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged(nameof(Apellido));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set
            {
                _contrasena = value;
                OnPropertyChanged(nameof(Contrasena));
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public string Rol
        {
            get { return _rol; }
            set
            {
                _rol = value;
                OnPropertyChanged(nameof(Rol));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelCrearUsuario(Window window)
        {
            _window = window;
            CrearUsuario = new RelayCommand(crearUsuario);
            Cancelar = new RelayCommand(cancelar);
        }

        public void crearUsuario()
        {
            Usuario usuario = new Usuario(Nombre, Apellido, Email, Contrasena, Telefono, Rol);
            modeloBBDD bd = new modeloBBDD();

            int id = bd.insertarUsuario(usuario);
            usuario.ID = id;
            UsuarioCreado?.Invoke(this, usuario);
            cancelar();
        }

        public void cancelar()
        {
            _window.Close();
        }
    }
}
