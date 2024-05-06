using ProjectManagerApi.Models.Domain;

namespace ProjectManagerApi.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
