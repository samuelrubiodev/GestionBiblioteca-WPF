﻿using System;
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
    /// Lógica de interacción para GestionBiblioteca.xaml
    /// </summary>
    public partial class GestionBiblioteca : Window
    {
        public GestionBiblioteca()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GestionLibros gestionLibros = new GestionLibros();
            gestionLibros.Show();
            this.Close();
        }
    }
}
