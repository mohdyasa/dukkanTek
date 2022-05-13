
namespace DukkanTek.Services.ProductService;
public interface IProductService
{
    Task<IEnumerable<ProductDataDto>> GetAsync();
    Task<bool> UpdateStatusAsync(string id, string status);
}

