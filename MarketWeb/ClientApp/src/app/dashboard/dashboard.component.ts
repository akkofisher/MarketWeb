import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DashboardService } from 'src/services/dashboard.service';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private router: Router,
    private dashboardService: DashboardService,
  ) {

    this.dashboardService.GetMarketPrices("1").subscribe(result => {
      this.forecasts = result;
    }, dataError => {
      console.log(dataError)
    });
  }

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
