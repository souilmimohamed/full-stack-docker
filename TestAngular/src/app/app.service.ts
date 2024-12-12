import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  constructor(private http: HttpClient) { }
  MODULE="Weather/GetWeatherForecast/"

  GetWeatherForecast(){
    return this.http.get<any>(`${environment.apiUrl}${this.MODULE}`);
  }
}
