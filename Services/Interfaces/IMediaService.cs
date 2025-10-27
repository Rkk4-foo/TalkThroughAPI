namespace TalkThroughAPI.Services.Interfaces
{
    public interface IMediaService
    {

        public byte[] GetDefaultImageBytes(string path);
        public byte[] Base64ToByteArray(string base64);
    }
}
