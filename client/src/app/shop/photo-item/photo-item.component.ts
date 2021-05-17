import { Component, Input, OnInit } from '@angular/core';
import { IPhotograph } from '../../shared/models/photograph.interface';

@Component({
  selector: 'app-photo-item',
  templateUrl: './photo-item.component.html',
  styleUrls: ['./photo-item.component.css']
})
export class PhotoItemComponent implements OnInit {
  @Input() photograph: IPhotograph;

  constructor() { }

  ngOnInit() {
  }

}
