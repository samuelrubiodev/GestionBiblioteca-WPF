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
    public class ViewModelGestionUsuarios : INotifyPropertyChanged
    {
        private GestionUsuarios _gestionUsuarios;
        private GestionBiblioteca _gestionBiblioteca;

        private int _id { get; set; }
        private string _nombre { get; set; }
        private string _apellido { get; set; }
        private string _email { get; set; }
        private string _contrasena { get; set; }
        private string _telefono { get; set; }
        private string _rol { get; set; }
        private Usuario _usuarioSeleccionado { get; set; }

        public ICommand CrearUsuario { get; set; }
        public ICommand EliminarUsuario { get; set; }
        public ICommand MenuPrincipal { get; set; }

        private ObservableCollection<Usuario> _usuarios = new ObservableCollection<Usuario>();
        public ObservableCollection<Usuario> Usuarios
        {
            get { return _usuarios; }
            set
            {
                if (value != _usuarios)
                {
                    _usuarios = value;
                    OnPropertyChanged(nameof(Usuarios));
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

        public Usuario UsuarioSeleccionado
        {
            get { return _usuarioSeleccionado; }
            set
            {
                if (value != _usuarioSeleccionado)
                {
                    _usuarioSeleccionado = value;
                    OnPropertyChanged(nameof(UsuarioSeleccionado));
                }
            }
        }

        public ViewModelGestionUsuarios(GestionUsuarios gestionUsuarios, GestionBiblioteca gestionBiblioteca)
        {
            _gestionUsuarios = gestionUsuarios;
            _gestionBiblioteca = gestionBiblioteca;

            Usuarios = new ObservableCollection<Usuario>();
            CrearUsuario = new RelayCommand(crearUsuario);
            EliminarUsuario = new RelayCommand(eliminarUsuario);
            MenuPrincipal = new RelayCommand(menuPrincipal);
            anadirUsuarios();
        }

        public void menuPrincipal()
        {
            _gestionBiblioteca.Show();
            _gestionUsuarios.Close();
        }

        public void anadirUsuarios()
        {
            modeloBBDD modeloBBDD = new modeloBBDD();
            List<Usuario> usuarios = modeloBBDD.consultarUsuarios();
            foreach (Usuario usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }
        }

        public void crearUsuario()
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            ViewModelCrearUsuario viewModelCrearUsuario = (ViewModelCrearUsuario)crearUsuario.DataContext;
            viewModelCrearUsuario.UsuarioCreado += OnUsuarioCreado;
            crearUsuario.Show();
        }

        private void OnUsuarioCreado(object sender, Usuario nuevoUsuario)
        {
            Usuarios.Add(nuevoUsuario);
        }

        public void eliminarUsuario()
        {
            if (UsuarioSeleccionado != null)
            {
                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el prestamo '{UsuarioSeleccionado.Nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    modeloBBDD modeloBBDD = new modeloBBDD();
                    modeloBBDD.eliminarUsuario(UsuarioSeleccionado);
                    Usuarios.Remove(UsuarioSeleccionado);
                    UsuarioSeleccionado = null;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro para eliminarlo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
