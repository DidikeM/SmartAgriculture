import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuyCreditComponent } from './buy-credit/buy-credit.component';
import { SellCreditComponent } from './sell-credit/sell-credit.component';
import { WithdrawCreditComponent } from './withdraw-credit/withdraw-credit.component';


const routes: Routes = [
  {
   path: '',
   children:[
    { path:'buycredit', component: BuyCreditComponent },
    { path:'sellcredit', component: SellCreditComponent },
    { path:'withdrawcredit', component: WithdrawCreditComponent },
   ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
