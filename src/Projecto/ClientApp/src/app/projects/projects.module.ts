import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectComponent } from './project/project.component';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectsNavbarComponent } from './projects-navbar/projects-navbar.component';


@NgModule({
  declarations: [ProjectsComponent, ProjectComponent, ProjectsListComponent, ProjectsNavbarComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule
  ]
})
export class ProjectsModule { }
