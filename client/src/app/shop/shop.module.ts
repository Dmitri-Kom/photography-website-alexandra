import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { PhotoItemComponent } from './photo-item/photo-item.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [ShopComponent, PhotoItemComponent],
  exports: [ShopComponent]
})
export class ShopModule { }
