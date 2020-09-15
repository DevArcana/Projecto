import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectComponent } from './projects-list/project/project.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { CreateProjectFormComponent } from './create-project-form/create-project-form.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ProjectsComponent, ProjectsListComponent, ProjectComponent, ProjectDetailsComponent, CreateProjectFormComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    ReactiveFormsModule
  ]
})
export class ProjectsModule { }
