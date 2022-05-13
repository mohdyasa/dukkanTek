namespace DukkanTek.Repository;
public interface IRepository
{
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class;
    Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;
    Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;

    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    public DbSet<T> GetRepository<T>() where T : class;
    public List<T> OrderByToList<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes) where T : class;
    IQueryable<T> Query<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : class;
    //public int ExecWithStoreProcedure(string query, params object[] parameters);
}

