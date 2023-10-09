using DotnetApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class AppRepository
  {
    private readonly PostgresContext _dbContext;

    public AppRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<App> GetById(int id)
    {
      return _dbContext
        .App
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public int Create(App app)
    {
      _dbContext.Add<App>(app);
      _dbContext.SaveChanges();

      return app.Id;

    }

    public IEnumerable<App> Get()
    {
      return _dbContext
        .App
        .ToArray();
    }

    public int Update(App app)
    {
      _dbContext
          .App
          .Update(app);

      _dbContext.SaveChanges();

      return app.Id;
    }

    public int Delete(App app)
    {
      _dbContext
        .App
        .Remove(app);

      _dbContext.SaveChanges();

      return app.Id;
    }
  }
}
