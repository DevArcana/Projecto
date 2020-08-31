import { Component, OnInit, ChangeDetectionStrategy, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-project-button',
  templateUrl: './add-project-button.component.html',
  styleUrls: ['./add-project-button.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddProjectButtonComponent implements OnInit {

  @Output() createProject = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

}
