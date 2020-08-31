import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProjectButtonComponent } from './add-project-button.component';

describe('AddProjectButtonComponent', () => {
  let component: AddProjectButtonComponent;
  let fixture: ComponentFixture<AddProjectButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddProjectButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProjectButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
