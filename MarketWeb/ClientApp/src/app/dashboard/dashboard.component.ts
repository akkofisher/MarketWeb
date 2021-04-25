import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DashboardService } from 'src/services/dashboard.service';
import { Company, CompanyMarketPrice, CompanyPriceList, Market } from 'src/models/companyPrice';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { timer } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public companyPriceList: CompanyPriceList[];
  public companyList: Market[];
  public marketList: Company[];
  public companyMarketPrice: CompanyMarketPrice[] = [];
  public companyPrice: number;
  public instantUpdateTable: boolean = true;

  public addOrUpdatePriceForm = new FormGroup({
    CompanyId: new FormControl('', Validators.required),
    MarketId: new FormControl('', Validators.required),
    Price: new FormControl('', Validators.required),
  });

  constructor(
    //http: HttpClient,
    // @Inject('BASE_URL') baseUrl: string,
    // private router: Router,
    private dashboardService: DashboardService,
  ) {

    this.dashboardService.GetNames().subscribe(result => {
      this.companyList = result.companies;
      this.marketList = result.markets;
    }, dataError => {
      console.log(dataError)
    });

    this.updateTable();

    const reloadInterval = 5000;

    timer(0, reloadInterval).pipe(
      mergeMap(async () => this.updateTable())
    ).subscribe()
  }

  updateTable() {
    this.dashboardService.GetCompanyPrices().subscribe(result => {
      this.companyPriceList = result;
    }, dataError => {
      console.log(dataError)
    });
  }

  changeCompanyValue() {
    if (this.addOrUpdatePriceForm.get('CompanyId').value) {
      this.dashboardService.GetPricesByCompanyId(Number(this.addOrUpdatePriceForm.get('CompanyId').value)).subscribe(result => {
        this.companyMarketPrice = result;
        this.showCompanyCurrentPrice();
      }, dataError => {
        console.log(dataError)
      });
    } else {
      this.companyMarketPrice = [];
      this.companyPrice = null;
    }
  }

  showCompanyCurrentPrice() {
    var existCompanyPrice = this.companyMarketPrice.find(x =>
      x.companyId === Number(this.addOrUpdatePriceForm.get('CompanyId').value) &&
      x.marketId == Number(this.addOrUpdatePriceForm.get('MarketId').value));

    this.companyPrice = existCompanyPrice != null ? existCompanyPrice.price : null;
  }

  onSubmit() {
    // this.isSubmitted = true;

    if (this.addOrUpdatePriceForm.valid) {

      this.dashboardService.AddOrUpdateCompanyPrice(this.addOrUpdatePriceForm.value).subscribe(result => {
        this.changeCompanyValue();
        if (this.instantUpdateTable) {
          this.updateTable();
        }
      }, dataError => {
        console.log(dataError)
      });

    } else {
      alert(JSON.stringify(this.addOrUpdatePriceForm.value))
    }
  }

}

