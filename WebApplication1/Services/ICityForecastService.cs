using WebApplication1.Models;

namespace WebApplication1.Services
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
