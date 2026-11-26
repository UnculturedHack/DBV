using System.Diagnostics;
using DBVServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries =
        //[
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //];

        #region Fields

        private readonly IDBAccessProvider DbAccProvider = null;

        #endregion Fields

        #region Constructors

        public WeatherForecastController(IDBAccessProvider dbAccProvider)
        {
            Debug.Assert(dbAccProvider != null);
            DbAccProvider = dbAccProvider;
        }

        #endregion Constructors

        #region Public Methods

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
        }

        #endregion Public Methods
    }
}
