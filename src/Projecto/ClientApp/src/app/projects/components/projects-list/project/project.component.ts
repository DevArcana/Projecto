import { Project } from './../../../models/Project';
import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProjectComponent implements OnInit {

  @Input() project!: Project;

  constructor() { }

  ngOnInit(): void {
  }

}
