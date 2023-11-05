import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";

import { DashboardLayoutComponent } from './components/layouts/dashboard-layout/dashboard-layout.component';
import { GeneralLayoutComponent } from './components/layouts/general-layout/general-layout.component';

const routes : Routes = [
  
    // App Routes
    {
        path: '',
        component: GeneralLayoutComponent,
        children: [
            {
                path: '',
                redirectTo: '/',
                pathMatch: 'full'
            },
            {
                path: '',
                loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule)
            }
        ]
    },

     // Auth Routes
     {
        path: '',
        component: GeneralLayoutComponent,
        children: [
            {
                path: 'auth',
                loadChildren: () => import('./components/auth/auth.module').then(m => m.AuthModule)
            }
        ]
    },
    
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}