using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tema5_JuegoPreguntas
{
    class AzureBlobStorageService
    {
        public string subirImagen(string ruta)
        {

            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialaaron;AccountKey=pDQGDqaneolaafs2hKdXYh4JQ/8Hs3VxJcRcaDJES2EdgGqmxABXgoQkMSY6Tg223B+Qjg51wGyV+AStJTpM3Q==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
            string nombreContenedorBlobs = "trivial"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure
            string rutaImagen = ruta;

            //Obtenemos el cliente del contenedor
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            //Una vez subida, obtenemos la URL para referenciarla
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;

            return urlImagen;
        }
    }
}
