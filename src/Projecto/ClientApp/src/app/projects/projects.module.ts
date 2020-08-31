import { LayoutModule } from './../layout/layout.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectComponent } from './project/project.component';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectsNavbarComponent } from './projects-navbar/projects-navbar.component';
import { NoProjectsFoundComponent } from './no-projects-found/no-projects-found.component';
import { CreateProjectFormComponent } from './create-project-form/create-project-form.component';


@NgModule({
  declarations: [
    ProjectsComponent,
    ProjectComponent,
    ProjectsListComponent,
    ProjectsNavbarComponent,
    NoProjectsFoundComponent,
    CreateProjectFormComponent
  ],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    LayoutModule
  ]
})
export class ProjectsModule { }
