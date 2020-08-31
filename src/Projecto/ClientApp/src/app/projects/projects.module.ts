import { LayoutModule } from './../layout/layout.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectComponent } from './components/projects-list/project/project.component';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { ProjectsNavbarComponent } from './components/projects-navbar/projects-navbar.component';
import { NoProjectsFoundComponent } from './components/projects-list/no-projects-found/no-projects-found.component';
import { CreateProjectFormComponent } from './components/create-project-form/create-project-form.component';
import { AddProjectButtonComponent } from './components/add-project-button/add-project-button.component';

@NgModule({
  declarations: [
    ProjectsComponent,
    ProjectComponent,
    ProjectsListComponent,
    ProjectsNavbarComponent,
    NoProjectsFoundComponent,
    CreateProjectFormComponent,
    AddProjectButtonComponent
  ],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    LayoutModule
  ]
})
export class ProjectsModule { }
