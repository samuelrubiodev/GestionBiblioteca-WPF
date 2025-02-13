using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Lógica de interacción para GestionLibros.xaml
    /// </summary>
    public partial class GestionLibros : Window
    {
        public GestionLibros()
        {
            InitializeComponent();
            ViewModel.ViewModelGestionLibros vm = new ViewModel.ViewModelGestionLibros(this);
            this.DataContext = vm;
        }
    }
}
