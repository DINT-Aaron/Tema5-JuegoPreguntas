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
    class JsonService
    {
        public ObservableCollection<Pregunta> cargarJSON(string ruta)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(File.ReadAllText(ruta));
        }

        public void guardarJSON(Partida partida, string ruta)
        {
            File.WriteAllText(ruta, JsonConvert.SerializeObject(partida.ListaPreguntas));
        }
    }
}
