import { Grade, GradesService } from './../grades.service';
import { Subject } from './../student.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShowStudentService } from '../student.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-grade',
  templateUrl: './add-grade.component.html',
  styleUrls: ['./add-grade.component.css']
})
export class AddGradeComponent implements OnInit {
  form!:FormGroup;
  id!:number;
  subjects:Subject[]=[];
  grade!:number;
  constructor(private fb: FormBuilder,private studentService: ShowStudentService, private gradeService: GradesService, private route: ActivatedRoute, private router:Router)
  {
    this.route.params.subscribe(params => {
      this.id=params['id'];
    });
   }
  selectedSubject:Subject=null!;
  ngOnInit(): void {

    this.studentService.getSubjects().subscribe(res=>this.subjects=res)
    //this.selectedSubject=this.subjects[0];
    console.log(this.id)


  }
  onShow(){
    console.log("wybrano " + this.selectedSubject.id + " " + this.selectedSubject.subjectName + " "+ this.id +" "+this.grade)
  }
  onAddGrade(){
    var grade:Grade={
      mark:this.grade,
      studentId: this.id,
      subjectId: this.selectedSubject.id,
      subjectName:this.selectedSubject.subjectName

    }
    console.log(grade);
    this.gradeService.addGrade(grade, this.id).subscribe(res=>this.router.navigateByUrl('class/get/'+this.id))
  }

  onSubmit(){

     console.log(this.selectedSubject)
  }



}
