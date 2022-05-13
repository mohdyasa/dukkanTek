namespace DukkanTek.Services.ProductService;
public class ProductService : IProductService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;
    private readonly IUnitOfWork _uow;

    public ProductService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory;
        _uow = unitOfWorkFactory.Create();
    }
    public async Task<IEnumerable<ProductDataDto>> GetAsync()
    {
        return await _uow.Repository.GetRepository<Product>()
         .GroupBy(pv => pv.Status)
         .Select(g => new ProductDataDto(g.Count(), g.Key)).ToListAsync();

    }

    public async Task<bool> UpdateStatusAsync(string id, string status)
    {
        var productDetails = await _uow.Repository.FirstOrDefaultAsync<Product>(x => x.Id == Utils.Decode(id));

        if (productDetails is null)
            throw new NotFoundException();

        if (productDetails.Status != status)
            productDetails.Status = status;

        _uow.Repository.Update(productDetails);
        await _uow.SaveChanges();

        return true;
    }
}

