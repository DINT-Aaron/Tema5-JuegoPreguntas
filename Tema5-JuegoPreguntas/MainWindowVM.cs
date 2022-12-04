using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_JuegoPreguntas
{
    class MainWindowVM:ObservableObject
    {
        private Partida partida;

        private ObservableCollection<string> categorias;
        
        public ObservableCollection<string> Categorias
        {
            get { return categorias; }
            set { SetProperty(ref categorias, value); }
        }
        public MainWindowVM()
        {
            partida = new Partida();
        }
        public bool comprobarCategoriasContienenPregunta()
        {
            return partida.ListaPreguntas.Any(p => p.Equals("asdf"));
        }
        public void cargarJSON (){
            ObservableCollection<Pregunta> lista=new ObservableCollection<Pregunta>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string preguntasJson = File.ReadAllText(openFileDialog.FileName);
                lista = JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(preguntasJson);
            }

            partida.ListaPreguntas = lista;
        }
        public void guardarJSON()
        {
            ObservableCollection<Pregunta> lista;
            lista = new ObservableCollection<Pregunta>();

            //Exportar a un fichero JSON
            string personasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", personasJson);
        }
        public void añadirPregunta()
        {
            
        }
    }
}
