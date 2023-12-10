import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BazaarRoutingModule } from './bazaar-routing.module';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './product/product.component';
import { TabsComponent } from './product/tabs/tabs.component';


@NgModule({
  declarations: [
    IndexComponent,
    ProductComponent,
    TabsComponent
  ],
  imports: [
    CommonModule,
    BazaarRoutingModule
  ]
})
export class BazaarModule { }
