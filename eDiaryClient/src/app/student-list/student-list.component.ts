import { Student, ShowStudentService } from './../student.service';
import { Component, OnInit,  Input, Output, EventEmitter  } from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Grade } from '../grades.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students:Student[]=[];
  selectedClass:any = 1;

  constructor(private studentService: ShowStudentService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.selectedClass=params['id'];
    });
    this.studentService.getStudents(this.selectedClass).subscribe(res=>this.students=res);
  }
  getStudentsList(){
    console.log(typeof(this.selectedClass))
    this.studentService.getStudents(this.selectedClass).subscribe(res=>this.students=res);
    console.log(this.students);
  }
  onShowGrades(student:Student){
    console.log(student)
    this.router.navigateByUrl('student/get/'+student.id);
  }

  onAddGrade(id:Number){
    this.router.navigateByUrl('grade/addGrade/'+id);
  }


}
