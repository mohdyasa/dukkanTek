namespace DukkanTek.Repository.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly DukkanTekDbContext _databaseContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(DukkanTekDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IRepository Repository
    {
        get
        {
            return new GenericRepository(_databaseContext);
        }
    }

    public DbContext _Context => _databaseContext;

    public Task SaveChanges()
    {
        return _databaseContext.SaveChangesAsync();
    }
    public void BeginTransaction()
    {
        _transaction = _databaseContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            //SaveChanges();
            _transaction.Commit();
        }
        finally
        {
            _transaction.Dispose();
        }
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _databaseContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }
}

