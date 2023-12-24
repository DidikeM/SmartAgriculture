import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { BazaarRoutingModule } from './bazaar-routing.module';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './product/product.component';
import { TabsComponent } from './product/tabs/tabs.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    IndexComponent,
    ProductComponent,
    TabsComponent
  ],
  imports: [
    CommonModule,
    BazaarRoutingModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ]
})
export class BazaarModule { }
