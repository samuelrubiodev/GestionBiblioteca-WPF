using Biblioteca.Model;
using Biblioteca.View;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class ViewModelGestionPrestamos : INotifyPropertyChanged
    {
        private GestionPrestamo _gestionPrestamo;
        private GestionBiblioteca _gestionBiblioteca;

        private int _id { get; set; }
        private Libro _libro { get; set; }
        private Usuario _usuario { get; set; }
        private DateTime fechaPrestamo { get; set; }
        private DateTime fechaDevolucion { get; set; }

        public ICommand CrearPrestamo { get; set; }
        public ICommand EliminarPrestamo { get; set; }
        public ICommand MenuPrincipal { get; set; }

        private Prestamo _prestamoSeleccioando;
        private ObservableCollection<Prestamo> _prestamos = new ObservableCollection<Prestamo>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public Libro Libro
        {
            get { return _libro; }
            set
            {
                _libro = value;
                OnPropertyChanged(nameof(Libro));
            }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
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

        public ObservableCollection<Prestamo> Prestamos
        {
            get { return _prestamos; }
            set
            {
                _prestamos = value;
                OnPropertyChanged(nameof(Prestamos));
            }
        }

        public Prestamo PrestamoSeleccionado
        {
            get { return _prestamoSeleccioando; }
            set
            {
                _prestamoSeleccioando = value;
                OnPropertyChanged(nameof(PrestamoSeleccionado));
            }
        }

        public ViewModelGestionPrestamos(GestionPrestamo gestionPrestamo, GestionBiblioteca gestionBiblioteca)
        {
            _gestionPrestamo = gestionPrestamo;
            _gestionBiblioteca = gestionBiblioteca;
            anadirPrestamos();

            CrearPrestamo = new RelayCommand(crearPrestamo);
            EliminarPrestamo = new RelayCommand(eliminarPrestamo);
            MenuPrincipal = new RelayCommand(menuPrincipal);
        }

        public void menuPrincipal()
        {   
            _gestionPrestamo.Close();
            _gestionBiblioteca.Show();
        }

        public void anadirPrestamos()
        {
            modeloBBDD modelo = new modeloBBDD();
            List<Prestamo> prestamos = modelo.consultarPrestamos();

            foreach (Prestamo prestamo in prestamos)
            {
                Prestamos.Add(prestamo);
            }
        }

        public void crearPrestamo()
        {
            CrearPrestamo ventana = new CrearPrestamo();
            ViewModelCrearPrestamo viewModel = (ViewModelCrearPrestamo)ventana.DataContext;
            viewModel.PrestamoCreado += OnPrestamoCreado;
            ventana.Show();
        }

        private void OnPrestamoCreado(object sender, Prestamo prestamo)
        {
            Prestamos.Add(prestamo);
        }

        public void eliminarPrestamo()
        {
            if (PrestamoSeleccionado != null)
            {
                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el prestamo con ID: '{PrestamoSeleccionado.ID}'?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    modeloBBDD modelo = new modeloBBDD();
                    modelo.eliminarPrestamo(PrestamoSeleccionado);
                    Prestamos.Remove(PrestamoSeleccionado);
                    PrestamoSeleccionado = null;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro para eliminarlo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
