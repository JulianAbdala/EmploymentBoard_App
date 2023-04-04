namespace BolsaDeTrabajoAPI.Models
{
    public class UploadCVDto
    {
        public string StudentId { get; set; } //Este es el id del candidato al que le vamos a agregar el cv
        public IFormFile File { get; set; } //La propiedad donde va a venir el archivo.
    }
}
