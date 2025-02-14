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
    /// Lógica de interacción para GestionUsuarios.xaml
    /// </summary>
    public partial class GestionUsuarios : Window
    {
        public GestionUsuarios(GestionBiblioteca gestionBiblioteca)
        {
            InitializeComponent();
            ViewModelGestionUsuarios vm = new ViewModelGestionUsuarios(this, gestionBiblioteca);
            this.DataContext = vm;
        }
    }
}
