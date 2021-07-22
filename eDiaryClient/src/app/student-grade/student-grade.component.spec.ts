import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentGradeComponent } from './student-grade.component';

describe('StudentGradeComponent', () => {
  let component: StudentGradeComponent;
  let fixture: ComponentFixture<StudentGradeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentGradeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentGradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
