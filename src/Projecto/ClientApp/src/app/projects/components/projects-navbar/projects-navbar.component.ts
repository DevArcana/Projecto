import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-projects-navbar',
  templateUrl: './projects-navbar.component.html',
  styleUrls: ['./projects-navbar.component.scss']
})
export class ProjectsNavbarComponent implements OnInit {

  @Output() createNewProject = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

}
