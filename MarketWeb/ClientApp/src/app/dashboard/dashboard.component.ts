import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DashboardService } from 'src/services/dashboard.service';
import { CompanyPriceList } from 'src/models/companyPrice';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public companyPriceList: CompanyPriceList[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private router: Router,
    private dashboardService: DashboardService,
  ) {

    this.dashboardService.GetCompanyPrices().subscribe(result => {
      this.companyPriceList = result;
    }, dataError => {
      console.log(dataError)
    });
  }

}

