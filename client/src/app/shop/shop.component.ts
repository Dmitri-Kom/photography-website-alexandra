import { Component, OnInit } from '@angular/core';
import { IPhotograph } from '../shared/models/photograph.interface';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  photographs: IPhotograph[]

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.shopService.getPhotographs().subscribe(response => {
      this.photographs = response.data;   
    }, error => {
      console.log(error);
    });
  }

}
