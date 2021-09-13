import { Component, OnInit } from '@angular/core';
import { throwError } from 'rxjs';
import { CloudsDto, CoordDto, MainDto, SysDto, WeatherDto, WeatherForecastDto, WeatherForecastListDto, WeatherForecastService, WindDto } from '../../services/weather-forecast.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.styl']
})
export class WeatherForecastComponent implements OnInit {
  public id: number = 0;
  public name: string = '';;
  public coord: CoordDto;
  public main: MainDto;
  public dt: number = 0;
  public wind: WindDto;
  public sys: SysDto;
  public rain: string = '';
  public snow: string = '';
  public clouds: CloudsDto;
  public weather: WeatherDto[];
  public cod: string = '';
  public count: number = 0;
  public message: string = '';
  public weatherForecast: WeatherForecastDto[] = [];

  constructor(
    private weatherForecastService: WeatherForecastService
  ) { }

  ngOnInit(): void {
  }

  public async GetWeatherForecastForCity(cityName: string, unitType: string) {
    try {
      let weatherForecast = await this.weatherForecastService.GetWeatherForecastForCity(cityName, unitType);
      this.handleWeatherForecastListFromServer(weatherForecast);
    } catch (error) {
      return throwError('Load failed: Failed to get the city name or unit type');
    }
  }

  private handleWeatherForecastListFromServer(weatherForecast: WeatherForecastListDto) {
    this.cod = weatherForecast.Cod;
    this.count = weatherForecast.Count;
    this.message = weatherForecast.Message;
    this.weatherForecast = weatherForecast.WeatherForecast;
  }

  public async GetWeatherForecastForUniqueCity(cityId: number) {
    try {
      let weatherForecast = await this.weatherForecastService.GetWeatherForecastForUniqueCity(cityId);
      this.handleWeatherForecastFromServer(weatherForecast);
    } catch (error) {
      return throwError('Load failed: Failed to get the unique city id');
    }
  }

  private handleWeatherForecastFromServer(weatherForecast: WeatherForecastDto) {
    this.id = weatherForecast.Id;
    this.name = weatherForecast.Name;
    this.coord = weatherForecast.Coord;
    this.main = weatherForecast.Main;
    this.dt = weatherForecast.Dt;
    this.wind = weatherForecast.Wind;
    this.sys = weatherForecast.Sys;
    this.rain = weatherForecast.Rain;
    this.snow = weatherForecast.Snow;
    this.clouds = weatherForecast.Clouds;
    this.weather = this.weather;
  }
}
