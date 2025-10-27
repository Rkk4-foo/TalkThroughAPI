using System.Drawing;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Services
{
    public class MediaService : IMediaService
    {
        public byte[] GetDefaultImageBytes(string path)
        {
            //if (!File.Exists(path))
            //    throw new FileNotFoundException($"Imagen predeterminada no encontrada: {path}");

            return File.ReadAllBytes(path);
        }

        public byte[] Base64ToByteArray(string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}
