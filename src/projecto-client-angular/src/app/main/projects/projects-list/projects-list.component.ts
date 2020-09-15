import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Project from '../models/Project';
import { ProjectsService } from '../services/projects.service';

@Component({
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.scss']
})
export class ProjectsListComponent implements OnInit {
  
  public projects$!: Observable<Project[]>;

  constructor(public projectsService: ProjectsService) { }

  ngOnInit() {
    this.projects$ = this.projectsService.getProjects();
  }
}
