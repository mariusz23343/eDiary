import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { StudentAdd } from '../add-student/add-student.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ShowStudentService } from '../student.service';

export interface StudentToEdit{
  id:Number,
  login:string,
  name:string;
  surname:string;
  pesel:string;
  parentEmail:string,
  birthDate:Date
}

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {
  form!:FormGroup;
  constructor(private fb: FormBuilder, private route: ActivatedRoute,private router:Router, private service:ShowStudentService) {

   }

  ngOnInit(): void {
    this.service.getOneStudentToEdit(Number.parseInt(this.route.snapshot.paramMap.get('id')!)).subscribe(res=>this.createForm(res))
  }

  private createForm(student?:StudentToEdit){
    this.form = this.fb.group({
        id:new FormControl(student?.id),
        login:new FormControl(student?.login),
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
      this.service.EditStudent(this.form.value).subscribe(res=>this.router.navigateByUrl(''))
  }

}
