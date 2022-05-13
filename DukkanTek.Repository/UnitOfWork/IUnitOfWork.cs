namespace DukkanTek.Repository.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    Task SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
    public IRepository Repository { get; }
    public DbContext _Context { get; }
}
