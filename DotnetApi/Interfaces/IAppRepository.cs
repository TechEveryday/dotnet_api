using DotnetApi.Models;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IAppRepository
  {
    IEnumerable<App> Get();
    IEnumerable<App> GetById(int id);
    int Create(App app);
    int Update(App app);
    int Delete(App id);
  }
}
