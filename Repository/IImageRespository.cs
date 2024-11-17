namespace BloogBloom.Repository
{
    public interface IImageRespository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
