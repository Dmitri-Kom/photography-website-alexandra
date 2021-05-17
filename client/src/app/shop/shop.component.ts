import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ILocation } from '../shared/models/location.interface';
import { IPhotograph } from '../shared/models/photograph.interface';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  photographs: IPhotograph[];
  locations: ILocation[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getPhotographs();
    this.getLocations();
  }

  getPhotographs() {
    this.shopService.getPhotographs(this.shopParams).subscribe(response => {
      this.photographs = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    })
  }

  getLocations() {
    this.shopService.getLocations().subscribe(response => {
      this.locations = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    })
  }

  onLocationSelected(locationId: number) {
    this.shopParams.locationId = locationId;
    this.shopParams.pageNumber = 1;
    this.getPhotographs();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getPhotographs();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getPhotographs();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getPhotographs();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getPhotographs();
  }



}
