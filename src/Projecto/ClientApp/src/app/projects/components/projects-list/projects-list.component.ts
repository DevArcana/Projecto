import { Project } from './../../models/Project';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.scss']
})
export class ProjectsListComponent implements OnInit {

  projects: Project[] = [
    new Project('Project 1', 'project-1', 'Project 1\'s description. It is a very nice project indeed.')
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
