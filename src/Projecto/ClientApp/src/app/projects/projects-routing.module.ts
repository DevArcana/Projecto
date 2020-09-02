import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProjectsComponent } from './projects.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from '../auth/interceptor.service';

const routes: Routes = [{ path: '', component: ProjectsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ]
})
export class ProjectsRoutingModule { }
