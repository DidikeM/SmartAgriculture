import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IndexComponent } from './index/index.component'
import { ContactComponent } from './contact/contact.component';

const routes: Routes = [
  {
   path: '',
  //  component: IndexComponent,
   children:[
    { path:'', component: IndexComponent },
    { path: 'contact', component: ContactComponent },
   ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
