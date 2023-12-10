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
    
     // Forum Routes
     {
        path: '',
        component: GeneralLayoutComponent,
        children: [
            {
                path: 'forum',
                loadChildren: () => import('./components/forum/forum.module').then(m => m.ForumModule)
            }
        ]
    },
    
    // Bazaar Routes
    {
        path: '',
        component: GeneralLayoutComponent,
        children: [
            {
                path: 'bazaar',
                loadChildren: () => import('./components/bazaar/bazaar.module').then(m => m.BazaarModule)
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}