import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { IndexComponent } from "./index/index.component";
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [IndexComponent, ContactComponent],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
