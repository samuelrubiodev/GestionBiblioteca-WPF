using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca.View
{
    /// <summary>
    /// Lógica de interacción para CrearPrestamo.xaml
    /// </summary>
    public partial class CrearPrestamo : Window
    {
        public CrearPrestamo()
        {
            InitializeComponent();
            ViewModel.ViewModelCrearPrestamo vm = new ViewModel.ViewModelCrearPrestamo(this);
            this.DataContext = vm;
        }
    }
}
