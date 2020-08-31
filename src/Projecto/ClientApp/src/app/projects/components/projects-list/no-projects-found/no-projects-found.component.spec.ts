import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoProjectsFoundComponent } from './no-projects-found.component';

describe('NoProjectsFoundComponent', () => {
  let component: NoProjectsFoundComponent;
  let fixture: ComponentFixture<NoProjectsFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoProjectsFoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoProjectsFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
