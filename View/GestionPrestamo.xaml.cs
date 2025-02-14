using Biblioteca.ViewModel;
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
    /// Lógica de interacción para GestionPrestamo.xaml
    /// </summary>
    public partial class GestionPrestamo : Window
    {
        public GestionPrestamo(GestionBiblioteca gestionBiblioteca)
        {
            InitializeComponent();
            ViewModelGestionPrestamos viewModelGestionPrestamos = new ViewModelGestionPrestamos(this,gestionBiblioteca);
            this.DataContext = viewModelGestionPrestamos;
        }
    }
}
