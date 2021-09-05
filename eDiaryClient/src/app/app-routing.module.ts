import { DeleteStudentComponent } from './delete-student/delete-student.component';
import { AddGradeComponent } from './add-grade/add-grade.component';
import { AddClassComponent } from './add-class/add-class.component';
import { ClasslistComponent } from './classlist/classlist.component';
import { StudentListComponent } from './student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentGradeComponent } from './student-grade/student-grade.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { AddStudentToClassComponent } from './add-student-to-class/add-student-to-class.component';



const routes:Routes=[
  {path: 'class/get/:id', component: StudentListComponent},
  {path: 'student/get/:id', component: StudentGradeComponent},
  {path: '', component: ClasslistComponent},
  {path: 'student/addStudent/', component: AddStudentComponent},
  {path: 'class/addClass/', component: AddClassComponent},
  {path: 'grade/addGrade/:id', component: AddGradeComponent},
  {path: 'deleteStudent', component: DeleteStudentComponent},
  {path:'addStudentToClass', component: AddStudentToClassComponent}

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
