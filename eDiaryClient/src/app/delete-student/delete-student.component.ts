import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShowStudentService, Student } from '../student.service';

@Component({
  selector: 'app-delete-student',
  templateUrl: './delete-student.component.html',
  styleUrls: ['./delete-student.component.css']
})
export class DeleteStudentComponent implements OnInit {

  students:Student[]=[];


  constructor(private studentService: ShowStudentService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {

    this.studentService.getAllStudents().subscribe(res=>this.students=res);
  }

  onDeleteStudent(id:Number){
    this.studentService.deleteStudent(id).subscribe(res=>window.location.reload());
    window.location.reload();
  }


}
