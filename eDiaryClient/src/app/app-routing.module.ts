import { ClasslistComponent } from './classlist/classlist.component';
import { StudentListComponent } from './student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentGradeComponent } from './student-grade/student-grade.component';



const routes:Routes=[
  {path: 'class/get/:id', component: StudentListComponent},
  {path: 'student/get/:id', component: StudentGradeComponent},
  {path: '', component: ClasslistComponent},
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
