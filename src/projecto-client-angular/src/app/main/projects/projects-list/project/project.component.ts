import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import Project from '../../models/Project';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProjectComponent {
  @Input() public project!: Project;
}
