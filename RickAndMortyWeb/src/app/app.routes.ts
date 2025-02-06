import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: ()=> import('./dashboard/dashboard.component'),
    children:[
      {
        path: 'episodios/:page',
        title: 'Episodios',
        loadComponent: ()=> import('./dashboard/episodios/episodios.component')
      },
      {
        path: 'episodios',
        title: 'Episodios',
        loadComponent: ()=> import('./dashboard/episodios/episodios.component')
      },
      {
        path: 'Personajes',
        title: 'Personajes',
        loadComponent: ()=> import('./dashboard/personajes/personajes.component')
      },
      {
        path:'',
        redirectTo: '/dashboard/episodios',
        pathMatch: 'full'
      },
    ]
  },
  {
    path:'',
    redirectTo: '/dashboard/episodios',
    pathMatch: 'full'
  },
  {
    path:'**',
    redirectTo: '/dashboard/episodios',
    pathMatch: 'full'
  }
];
