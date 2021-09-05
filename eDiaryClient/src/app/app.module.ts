import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentListComponent } from './student-list/student-list.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StudentGradeComponent } from './student-grade/student-grade.component';
import { LoginComponent } from './login/login.component';
import { ClasslistComponent } from './classlist/classlist.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { AddClassComponent } from './add-class/add-class.component';
import { AddGradeComponent } from './add-grade/add-grade.component';
import { DeleteStudentComponent } from './delete-student/delete-student.component';
import { AddStudentToClassComponent } from './add-student-to-class/add-student-to-class.component';
@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    StudentGradeComponent,
    LoginComponent,
    ClasslistComponent,
    AddStudentComponent,
    AddClassComponent,
    AddGradeComponent,
    DeleteStudentComponent,
    AddStudentToClassComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
