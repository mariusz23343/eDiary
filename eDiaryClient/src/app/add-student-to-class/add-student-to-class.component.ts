import { AddClassToStudent, ShowStudentService, Subject } from './../student.service';
import { Component, OnInit } from '@angular/core';
import { Student } from '../student.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassesService } from '../classes.service';
export interface GetClass{
  schoolYear:string,
  className:string
  id:number
}
@Component({
  selector: 'app-add-student-to-class',
  templateUrl: './add-student-to-class.component.html',
  styleUrls: ['./add-student-to-class.component.css']
})
export class AddStudentToClassComponent implements OnInit {

  selectedStudent!:Student;
  selectedClass!:GetClass;
  schoolClasses:GetClass[]=[];
  students:Student[]=[];
  constructor(private classService:ClassesService, private studentService: ShowStudentService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
      this.classService.getClasses().subscribe(res=>this.schoolClasses = res);
      this.studentService.getStudentsWithoutClass().subscribe(res=>this.students = res);
  }
  onShow(){
      console.log(this.schoolClasses);
      console.log(this.students);
      console.log(this.selectedClass);
      console.log(this.selectedStudent);
  }
  onSave(){
    console.log('lol')
      let dto:AddClassToStudent={
        studentId:this.selectedStudent.id,
        classId:this.selectedClass.id
      }
      this.studentService.addClassToStudent(dto).subscribe(res=>this.router.navigateByUrl('class/get/'+this.selectedClass.id));
  }
}
