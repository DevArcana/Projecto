import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import Project from '../models/Project';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor() { }

  public getProjects(): Observable<Project[]> {
    return of([
      new Project('Project 1', 'project-1', 'An example project called project 1.'),
      new Project('Project 2', 'project-2'),
      new Project('Project 3', 'project-slug-can-be-different-than-name-and-quite-long', 'Unlike project 2, I have a description.')
    ]);
  }
}
