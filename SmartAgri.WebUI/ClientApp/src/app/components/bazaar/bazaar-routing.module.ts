import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  {
   path: '',
   children:[
    { path:'', component: IndexComponent },
    { path: 'product', component: ProductComponent },
   ] 
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BazaarRoutingModule { }
