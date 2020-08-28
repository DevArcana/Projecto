import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-no-projects-found',
  templateUrl: './no-projects-found.component.html',
  styleUrls: ['./no-projects-found.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NoProjectsFoundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
