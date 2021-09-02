import { AddClassComponent } from './add-class/add-class.component';
import { ClasslistComponent } from './classlist/classlist.component';
import { StudentListComponent } from './student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentGradeComponent } from './student-grade/student-grade.component';
import { AddStudentComponent } from './add-student/add-student.component';



const routes:Routes=[
  {path: 'class/get/:id', component: StudentListComponent},
  {path: 'student/get/:id', component: StudentGradeComponent},
  {path: '', component: ClasslistComponent},
  {path: 'student/addStudent/', component: AddStudentComponent},
  {path: 'class/addClass/', component: AddClassComponent},

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
