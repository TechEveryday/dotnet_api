using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CityForecastService : ICityForecastService
    {
        /**
         * @param City cityForecastToValidate
         * @return bool - returns false if the model is invalid
         */
        public bool ValidateCityForecastModel(CityForecast cityForecastToValidate)
        {
            return !string.IsNullOrWhiteSpace(cityForecastToValidate.Name)
                && cityForecastToValidate.Temperature != null
                && cityForecastToValidate.Date != null;
        }
    }
}
