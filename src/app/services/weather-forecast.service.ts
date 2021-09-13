import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../sharedservices/base.service';

@Injectable({
  providedIn: 'root'
})

export class WeatherForecastService extends BaseService {
	constructor(http: HttpClient) {
		super(http);
	}

  public async GetWeatherForecastForCity(cityName: string, unitType: string): Promise<WeatherForecastListDto> {
    const url = '/weatherforecast/city/' + cityName + '/' + unitType;
    return this.http.get<WeatherForecastListDto>(url).toPromise();
	}

  public async GetWeatherForecastForUniqueCity(cityId: number): Promise<WeatherForecastDto> {
    const url = '/weatherforecast/city/' + cityId;
    return this.http.get<WeatherForecastDto>(url).toPromise();
  }
}

export interface WeatherForecastListDto {
  Message: string;
  Cod: string;
  Count: number;
  WeatherForecast: WeatherForecastDto[];
}

export interface WeatherForecastDto {
  Id: number;
  Name: string;
  Coord: CoordDto;
  Main: MainDto;
  Dt: number;
  Wind: WindDto;
  Sys: SysDto;
  Rain: string;
  Snow: string;
  Clouds: CloudsDto;
  Weather: WeatherDto[];
}

export interface CoordDto {
  Latitude: number;
  Longitude: number;
}

export interface MainDto {
  Temp: number;
  FeelsLike: number;
  TempMin: number;
  TempMax: number;
  Pressure: number;
  Humidity: number;
}

export interface WindDto {
  Speed: number;
  Deg: number;
}

export interface SysDto {
  Id: number;
  Type: number;
  country: string;
  Sunrise: number;
  Sunset: number;
}

export interface CloudsDto {
  All: number;
}

export interface WeatherDto {
  Id: number;
  Main: string;
  Description: string;
  Icon: string;
}
