using Biblioteca.Model;
using Biblioteca.View;
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
    public class ViewModelPrincipal : INotifyPropertyChanged
    {
        private string _usuario;
        private string _contrasena;
        private Window _window;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand LoginCommand { get; set; }

        public String Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public String Contrasena
        {
            get { return _contrasena; }
            set
            {
                _contrasena = value;
                OnPropertyChanged(nameof(Contrasena));
            }
        }

        public ViewModelPrincipal(Window window)
        {
            LoginCommand = new RelayCommand(Login);
            _window = window;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool PuedeIniciarSesion()
        {
            return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasena);
        }


        public void Login()
        {
            modeloBBDD modeloBBDD = new modeloBBDD();
            List<Usuario> listaUsuarios = modeloBBDD.consultarUsuarios();

            bool usuarioCorrecto = false;

            foreach (Usuario usuario in listaUsuarios)
            {
                if (this.Usuario == usuario.Email && this.Contrasena == usuario.Contrasena 
                    && usuario.Rol == "ADMIN")
                {
                    usuarioCorrecto = true;
                    GestionBiblioteca gestionBiblioteca = new GestionBiblioteca();
                    _window.Close();
                    gestionBiblioteca.Show();
                    break;
                } else
                {
                    usuarioCorrecto = false;
                }
            }

            if (!usuarioCorrecto)
            {
                MessageBox.Show("El usuario no es Administrador y/o el email y/o contraseña son incorrectos", "Login incorrecto", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
