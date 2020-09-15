import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectComponent } from './projects-list/project/project.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';


@NgModule({
  declarations: [ProjectsComponent, ProjectsListComponent, ProjectComponent, ProjectDetailsComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule
  ]
})
export class ProjectsModule { }
