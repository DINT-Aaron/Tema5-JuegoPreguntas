using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema5_JuegoPreguntas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void cargarDeJSONButton_Click(object sender, RoutedEventArgs e)
        {
            vm.cargarJSON();
        }
        private void guardarEnJSONButton_Click(object sender, RoutedEventArgs e)
        {
            vm.guardarJSON();
        }
        private void eliminarPreguntaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.eliminarPregunta();
        }
        private void añadirPreguntaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.añadirPregunta(preguntaAñadirPreguntaTextBox.Text, respuestaAñadirPreguntaTextBox.Text, imagenAñadirPreguntaTextBox.Text, dificultadAñadirPreguntaComboBox.SelectedItem.ToString(), categoriaAñadirPreguntaComboBox.SelectedItem.ToString());
            vm.DialogService.mostrarMensaje("La pregunta se ha añadido correctamente","Pregunta añadida");
        }
        private void limpiarFormularioButton_Click(object sender, RoutedEventArgs e)
        {
            preguntaAñadirPreguntaTextBox.Text = null;
            respuestaAñadirPreguntaTextBox.Text = null;
            imagenAñadirPreguntaTextBox.Text = null;
            dificultadAñadirPreguntaComboBox.SelectedItem = null;
            categoriaAñadirPreguntaComboBox.SelectedItem = null;
        }

        private void validarRespuestaJuegoButton_Click(object sender, RoutedEventArgs e)
        {
            vm.validarRespuesta(respuestaJuegoTextBox.Text);
        }

        private void nuevaPartidaJuegoButton_Click(object sender, RoutedEventArgs e)
        {
            double dificultad = nivelDificultadPartidaSlider.Value;
            vm.nuevaPartida(dificultad);
        }

        private void examinarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.subirImagen();
        }
    }
}
