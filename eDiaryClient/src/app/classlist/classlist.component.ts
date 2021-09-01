import { ClassesService } from './../classes.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

export interface ClassList{
  id:number,
  className:string,
  schoolYear:string,

}
@Component({
  selector: 'app-classlist',
  templateUrl: './classlist.component.html',
  styleUrls: ['./classlist.component.css']
})
export class ClasslistComponent implements OnInit {
  classList:ClassList[]=[];
  constructor(private route: ActivatedRoute, private router:Router, private cervice: ClassesService) { }
  // this.gradeService.getOneStudentsGrades(this.id).subscribe(res=>this.studentsGrades=res)
  ngOnInit(): void {
    this.cervice.getClasses().subscribe(res=>this.classList = res);

  }
  onShowStudent(oneClass: ClassList):void{
    //this.router.navigateByUrl('student/get/'+student.id);
    this.router.navigateByUrl('class/get/'+oneClass.id);
  }

}
