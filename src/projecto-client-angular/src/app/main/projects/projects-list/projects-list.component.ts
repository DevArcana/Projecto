import { Component } from '@angular/core';
import { ProjectsService } from '../services/projects.service';

@Component({
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.scss']
})
export class ProjectsListComponent {
  constructor(public projects: ProjectsService) { }
}
