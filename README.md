WeatherApp is a web application that allows users to check the current weather and daily forecast for any city. It consumes data from an external weather API, stores it in a SQL Server database, and exposes it through RESTful endpoints built with ASP.NET Core.

Main Features

Current weather 

7-day daily forecast lookup by city

Data persistence in SQL Server

External API consumption (Weatherbit)

Automatic retries with resilience policy

Cache

Responsive web interface with city selector

Current Weather GET /api/weather/GetWeather

Example response:

Code
{
  "min_temp": 23.1,
  "max_temp": 30.2,
  "datetime": "2025-09-11",
  "description": "Thunderstorm with rain"
}

Daily Forecast GET /api/weather/forecast?city={cityName}

Example response:

Code
[
  {
    "min_temp": 23.1,
    "max_temp": 30.2,
    "datetime": "2025-09-11",
    "description": "Thunderstorm with rain"
  },
  ...
]

Project Configuration

appsettings.json

Código
{
  "ConnectionStrings": {
    "WeatherAppConectionString": "your-connection-string"
  },
  "APIConfiguration": {
    "PathAPI": "https://api.weatherbit.io/v2.0/forecast/daily",
    "key": "your-API-key"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

Frontend

Main page with city selector

Buttons to view current weather or forecast

Responsive design with custom CSS

Data fetched using fetch() or $.getJSON()

Testing with api.http

Code
### Current Weather
GET http://localhost:5163/api/weather/GetWeather
Accept: application/json

### Forecast
GET http://localhost:5163/api/weather/forecast?city=San%20Salvador
Accept: application/json


Requirements

.NET 7 or higher

SQL Server Express

Valid API key from Weatherbit.io

Visual Studio or VS Code