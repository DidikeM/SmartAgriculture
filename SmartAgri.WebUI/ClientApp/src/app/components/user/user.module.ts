import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UserRoutingModule } from './user-routing.module';
import { BuyCreditComponent } from './buy-credit/buy-credit.component';
import { SellCreditComponent } from './sell-credit/sell-credit.component';
import { WithdrawCreditComponent } from './withdraw-credit/withdraw-credit.component';
import { PastAdvertisementsComponent } from './past-advertisements/past-advertisements.component';
import { ActiveAdvertisementsComponent } from './active-advertisements/active-advertisements.component';
import { SettingsComponent } from './settings/settings.component';


@NgModule({
  declarations: [
    BuyCreditComponent,
    SellCreditComponent,
    WithdrawCreditComponent,
    PastAdvertisementsComponent,
    ActiveAdvertisementsComponent,
    SettingsComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    ReactiveFormsModule
  ]
})
export class UserModule { }
