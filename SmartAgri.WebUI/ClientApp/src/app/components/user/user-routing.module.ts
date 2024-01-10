import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuyCreditComponent } from './buy-credit/buy-credit.component';
import { SellCreditComponent } from './sell-credit/sell-credit.component';
import { WithdrawCreditComponent } from './withdraw-credit/withdraw-credit.component';
import { PastAdvertisementsComponent } from './past-advertisements/past-advertisements.component';
import { ActiveAdvertisementsComponent } from './active-advertisements/active-advertisements.component';
import { SettingsComponent } from './settings/settings.component';


const routes: Routes = [
  {
   path: '',
   children:[
    { path:'buycredit', component: BuyCreditComponent },
    { path:'sellcredit', component: SellCreditComponent },
    { path:'withdrawcredit', component: WithdrawCreditComponent },
    { path:'pastadvertisement', component: PastAdvertisementsComponent },
    { path:'activeadvertisement', component: ActiveAdvertisementsComponent },
    { path:'settings', component: SettingsComponent },
   ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
