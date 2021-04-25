import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CompanyPriceData } from 'src/models/companyPrice';

@Injectable({ providedIn: 'root' })
export class DashboardService {

  constructor(private http: HttpClient) {
  }

  GetNames() {
    return this.http.get<any>(`${environment.apiUrl}/dashboard/GetNames`);
  }

  GetCompanyPrices() {
    return this.http.get<any[]>(`${environment.apiUrl}/dashboard/GetCompanyPrices`);
  }

  GetCompanyById(data: any) {
    let params = new HttpParams();
    params = params.append('id', data);
    return this.http.get<any[]>(`${environment.apiUrl}/dashboard/GetCompanyById`, { params });
  }

  GetPricesByCompanyId(data: any) {
    let params = new HttpParams();
    params = params.append('id', data);
    return this.http.get<any[]>(`${environment.apiUrl}/dashboard/GetPricesByCompanyId`, { params });
  }

  AddOrUpdateCompanyPrice(data: CompanyPriceData) {
    let bodyParams = new HttpParams();
    Object.keys(data).forEach(function (key) {
      bodyParams = bodyParams.append(key, data[key]);
    });

    return this.http.post<boolean>(`${environment.apiUrl}/dashboard/AddOrUpdateCompanyPrice`, bodyParams);
  }

}

