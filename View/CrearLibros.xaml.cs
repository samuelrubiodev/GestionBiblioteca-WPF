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
    /// Lógica de interacción para CrearLibros.xaml
    /// </summary>
    public partial class CrearLibros : Window
    {
        public CrearLibros()
        {
            InitializeComponent();
            ViewModelCrearLibros viewModelCrearLibros = new ViewModelCrearLibros(this);
            this.DataContext = viewModelCrearLibros;
        }
    }
}
