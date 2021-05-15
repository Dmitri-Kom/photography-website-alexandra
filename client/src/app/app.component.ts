import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination.interface';
import { IPhotograph } from './models/photograph.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Photography-Alexandra';

  photographs: IPhotograph[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/photographs?pageSize=50').subscribe((response: IPagination) => {
      this.photographs = response.data;
    }, error => {
      console.log(error);
    })
  }
}
