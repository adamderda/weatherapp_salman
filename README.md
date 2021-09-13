# WeatherForecastAPIClient
API Client to get weather information for city from openweathermap
MVC and Angular web application that can be used for searching information about current weather conditions for a specific city using https://openweathermap.org. 
https://openweathermap.org is used for fetching the weather data. 

The web application is focusing on following things

o   allow a user to enter a city name, as well as switch between metric and imperial units 

o   in case a user enters a city name that is not unique and exists in multiple countries (e.g. London - http://api.openweathermap.org/data/2.5/find?q=London&appid={apikey}), they should be prompted and be able to clarify their selection  

o   selected city and units should be persisted within the user's browser, so next time they visit the page, data gets prepopulated
