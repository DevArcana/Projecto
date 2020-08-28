import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  isFormVisible = false;

  constructor() { }

  ngOnInit(): void {
  }

  public openProjectCreationForm(): void {
    this.isFormVisible = true;
  }

  public closeProjectCreationForm(): void {
    this.isFormVisible = false;
  }
}
