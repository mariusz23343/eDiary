import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'eDiaryClient';
  OnInit(){}
  constructor(private route: ActivatedRoute, private router:Router){}
  onAddStudent(){
    console.log('lol');
    this.router.navigateByUrl( 'student/addStudent/');
  }
  onAddClass(){
    console.log('lol');
    this.router.navigateByUrl( 'class/addClass/');
  }
  onDeleteStudent(){
    this.router.navigateByUrl( 'deleteStudent');
  }
  onAddStudentToClass(){
    this.router.navigateByUrl('addStudentToClass');
  }
  onHome(){
    this.router.navigateByUrl('');
  }
}
