import { StudentListComponent } from './student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentGradeComponent } from './student-grade/student-grade.component';



const routes:Routes=[
  {path: '', component: StudentListComponent},
  {path: 'student/get/:id', component: StudentGradeComponent},
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
