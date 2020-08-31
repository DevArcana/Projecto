import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './auth/login/login.component';
import { Error404Component } from './error404/error404.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'projects'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'projects',
    loadChildren: () => import('./projects/projects.module').then((m) => m.ProjectsModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    component: Error404Component
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
