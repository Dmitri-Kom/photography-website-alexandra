import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { IPagination } from '../shared/models/pagination.interface';

@Injectable()
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getPhotographs(): Observable<IPagination> {
    return this.http.get<IPagination>(this.baseUrl + 'photographs?pageSize=50');
  }

}
