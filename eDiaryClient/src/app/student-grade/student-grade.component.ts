import { Grade, GradesService } from './../grades.service'
import { Component, OnInit } from '@angular/core'
import { Input, Output, EventEmitter  } from '@angular/core'
import {ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router'

@Component({
  selector: 'app-student-grade',
  templateUrl: './student-grade.component.html',
  styleUrls: ['./student-grade.component.css']
})
export class StudentGradeComponent implements OnInit {

  studentsGrades:Grade[]=[];
  private id:number=1;
  constructor(private gradeService: GradesService, private route: ActivatedRoute, private router:Router) {

  }

  ngOnInit(): void {

    console.log(this.id);
    this.gradeService.getOneStudentsGrades(this.id).subscribe(res=>this.studentsGrades=res)
  }
  onEditGrade(grade:Grade){

  }


}
