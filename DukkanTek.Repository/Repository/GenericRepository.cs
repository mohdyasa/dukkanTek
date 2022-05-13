namespace DukkanTek.Repository;
public class GenericRepository : IRepository
{
    protected readonly DukkanTekDbContext _context;
    public GenericRepository(DukkanTekDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> FindAsync<T>
   (Expression<Func<T, bool>> expression) where T : class
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<T> SingleOrDefaultAsync<T>
    (Expression<Func<T, bool>> expression) where T : class
    {
        return await _context.Set<T>().AsQueryable().SingleOrDefaultAsync(expression);
    }
    public async Task<T> FirstOrDefaultAsync<T>
   (Expression<Func<T, bool>> expression) where T : class
    {
        return await _context.Set<T>().AsQueryable().FirstOrDefaultAsync(expression);
    }

    public void Add<T>(T entity) where T : class
    {
        //_context.Entry(entity).State = EntityState.Added;
        _context.Set<T>().Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
    }
    public DbSet<T> GetRepository<T>() where T : class
    {
        return _context.Set<T>();
    }

    public List<T> OrderByToList<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes) where T : class
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (Expression<Func<T, object>> include in includes)
            query = query.Include(include);

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query.ToList();
    }
    public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : class
    {
        IQueryable<T> query = _context.Set<T>(); ;

        if (filter != null)
            query = query.Where(filter);
        foreach (var includeProperty in includeProperties.Split
                   (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query);
        }
        else
        {
            return query;
        }
    }
   
}

