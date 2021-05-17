import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { ILocation } from '../shared/models/location.interface';
import { IPagination } from '../shared/models/pagination.interface';
import { ShopParams } from '../shared/models/shopParams';

@Injectable()
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getPhotographs(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.locationId !== 0) {
      params = params.append('locationId', shopParams.locationId.toString())
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search)
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getLocations() {
    return this.http.get<ILocation[]>(this.baseUrl + 'photographs/locations');
  }

}
