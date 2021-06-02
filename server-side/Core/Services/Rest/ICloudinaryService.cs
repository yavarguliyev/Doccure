namespace Core.Services.Rest
{
    public interface ICloudinaryService
    {
        string Store(string file);
        string StoreResized(string file, int width, int height, string crop);
        string BuildUrl(string publicId, string crop = "fill", int width = 500, int height = 500);
        string BuildUrl(string publicId);
        void Delete(string publicId);
        string StoreFromUrl(string url);
    }
}