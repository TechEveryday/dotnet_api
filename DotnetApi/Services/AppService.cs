using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class AppService
  {
    private readonly IAppRepository _appRepository;

    public AppService(IAppRepository appRepository)
    {
      _appRepository = appRepository;
    }

    public int create(App app)
    {
      if (!this.ValidateModel(app))
        throw new Exception("Invalid App model");

      return _appRepository.Create(app);
    }

    public int update(App app)
    {
      if (!this.ValidateModel(app))
        throw new Exception("Invalid App model");

      App existingApp = _appRepository.GetById(app.Id).First();

      if (existingApp == null)
        throw new Exception("App not found");

      return _appRepository.Update(app);
    }

    public int delete(int id)
    {
      App existingApp = _appRepository.GetById(id).First();

      if (existingApp == null)
        throw new Exception("App not found");

      return _appRepository.Delete(existingApp);
    }

    public App[] get()
    {
      return (App[])_appRepository.Get();
    }

    public App[] getById(int id)
    {
      return (App[])_appRepository.GetById(id);
    }

    /**
     * @param City appToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateModel(App appToValidate)
    {
      return appToValidate != null
          && appToValidate.Id != 0
          && appToValidate.Name != null;
    }
  }
}
