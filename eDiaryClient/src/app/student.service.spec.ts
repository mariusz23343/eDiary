import { TestBed } from '@angular/core/testing';

import { ShowStudentService } from './student.service';

describe('StudentService', () => {
  let service: ShowStudentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShowStudentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
