import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class DashboardService {

  constructor(private http: HttpClient) {
  }

  GetMarketPrices(total: string) {
    let params = new HttpParams();
    params = params.append('total', total);
    return this.http.get<any[]>(`${environment.apiUrl}/dashboard/getmarketprices`, { params });
  }

}

