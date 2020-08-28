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

  public toggleProjectCreationForm(): void {
    this.isFormVisible = !this.isFormVisible;
  }
}
