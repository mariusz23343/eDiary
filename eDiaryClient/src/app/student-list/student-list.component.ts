import { Student, ShowStudentService } from './../student.service';
import { Component, OnInit,  Input, Output, EventEmitter  } from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students:Student[]=[];
  selectedClass:number=1;

  constructor(private studentService: ShowStudentService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {

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



}
