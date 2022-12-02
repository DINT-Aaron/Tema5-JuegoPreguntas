using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_JuegoPreguntas
{
    class MainWindowVM:ObservableObject
    {
        private Partida partida;
        private Pregunta preguntaActual;
        private MainWindowVM vm;
        public MainWindowVM()
        {
            
        }
        public void cargarJSON (){
            OpenFileDialog;
        }
    }
}
