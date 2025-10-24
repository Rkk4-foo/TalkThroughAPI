using System.Drawing;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Services
{
    public class MediaService : IMediaService
    {
        public byte[] ImageToByteArray(Image imageIn)
        {

            using var ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();

        }
    }
}
