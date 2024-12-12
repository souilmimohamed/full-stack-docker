import { Component,OnInit } from '@angular/core';
import {AppService} from './app.service';
import {take} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private service: AppService) {
  }
  title = 'TestAngular';
  ngOnInit(){
    this.service.GetWeatherForecast()
      .pipe(take(1))
      .subscribe(result=>{
        console.log(result);
      })
  }
}
