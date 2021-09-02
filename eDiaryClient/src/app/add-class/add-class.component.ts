import { ClassesService } from './../classes.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

export interface AddClass{
  schoolYear:string,
  className:string
}
@Component({
  selector: 'app-add-class',
  templateUrl: './add-class.component.html',
  styleUrls: ['./add-class.component.css']
})
export class AddClassComponent implements OnInit {

  form!:FormGroup;
  constructor(private fb: FormBuilder, private route: ActivatedRoute,private router:Router, private service:ClassesService) {

   }

  ngOnInit(): void {
    this.createForm();
  }
  private createForm(schoolClass?:AddClass){
    this.form = this.fb.group({
        schoolYear:new FormControl(schoolClass?.schoolYear),
        className: new FormControl(schoolClass?.className)
    });
    console.log(this.form);
  }
  onSubmit(event?:any){
    console.log(this.form.value);
    this.service.addClass(this.form.value).subscribe(res=>this.router.navigateByUrl(''));
  }
}
