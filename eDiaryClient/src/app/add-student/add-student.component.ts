import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ShowStudentService } from '../student.service';

export interface StudentAdd{
  login:string,
  password:string;
  name:string;
  surname:string;
  pesel:string;
  parentEmail:string,
  birthDate:Date
}
@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  form!:FormGroup;
  constructor(private fb: FormBuilder, private route: ActivatedRoute,private router:Router, private service:ShowStudentService) {

   }

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(student?:StudentAdd){
    this.form = this.fb.group({
        login:new FormControl(student?.login),
        password:new FormControl(student?.password),
        name:new FormControl(student?.name),
        surname:new FormControl(student?.surname),
        pesel:new FormControl(student?.pesel),
        parentEmail:new FormControl(student?.parentEmail),
        birthDate: new FormControl(student?.birthDate)
    });
    console.log(this.form);
  }
  onSubmit(event?:any){

      
      console.log(this.form.value)
      this.service.addStudent(this.form.value).subscribe(res=>this.router.navigateByUrl(''))
  }
}
