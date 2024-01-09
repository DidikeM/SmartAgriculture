import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UserRoutingModule } from './user-routing.module';
import { BuyCreditComponent } from './buy-credit/buy-credit.component';
import { SellCreditComponent } from './sell-credit/sell-credit.component';
import { WithdrawCreditComponent } from './withdraw-credit/withdraw-credit.component';


@NgModule({
  declarations: [
    BuyCreditComponent,
    SellCreditComponent,
    WithdrawCreditComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    ReactiveFormsModule
  ]
})
export class UserModule { }
