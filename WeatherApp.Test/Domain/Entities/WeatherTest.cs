using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;
using WeatherApp.WeatherbitAPI.Entities;

namespace WeatherApp.Test.Domain.Entities
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void CreateEntity_AllCorrect() 
        {
            var weather = new WeatherApp.Domain.Entities.Weather(max_temp: 31.1, min_temp: 23, datetime: DateTime.Today, description: "Moderate rain");
            Assert.IsNotNull(weather);
            Assert.IsNotNull(weather.Id);
            Assert.AreEqual(weather.max_temp, 31.1);
            Assert.AreEqual(weather.min_temp, 23);
            Assert.AreEqual(weather.description, "Moderate rain");
        }
    }
}
