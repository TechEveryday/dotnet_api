using DotnetApi.Models;

namespace DotnetApi.Services
{
    public interface ICityForecastService
    {
        /**
        * @param City cityForecastToValidate
        * @return bool - returns false if the model is invalid
        */
        public abstract bool ValidateCityForecastModel(CityForecast cityForecastToValidate);
    }
}
