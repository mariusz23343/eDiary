import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { StudentAdd } from './add-student/add-student.component';
import { StudentToEdit } from './edit-student/edit-student.component';
export interface Student{
  id:Number,
  name:string,
  surname:string,
  date:Date,
  emailParent:string,
  pesel:string
}
export interface Subject{
  id:number,
  subjectName:string
}
export interface AddClassToStudent{
  studentId:Number,
  classId:number
}
@Injectable({
  providedIn: 'root'
})
export class ShowStudentService {
  private actualisation: BehaviorSubject<string> = new BehaviorSubject<string>('');
  constructor(private http:HttpClient) { }
  getStudents(classId:number):Observable<Student[]>{
    return this.http.get<Student[]>('https://localhost:44354/api/StudentChange/id?id='+classId);
  }
  addStudent(student:StudentAdd):Observable<StudentAdd>{
    return this.http.post<StudentAdd>("https://localhost:44354/api/Auth/registerStudent", student).pipe(tap(
      res=>this.actualisation.next('dodano studenta')
    ));
  }
  getSubjects():Observable<Subject[]>{
    return this.http.get<Subject[]>('https://localhost:44354/api/GradeStudent');
  }
  getAllStudents():Observable<Student[]>{
    return this.http.get<Student[]>('https://localhost:44354/api/StudentChange');
  }
  deleteStudent(id:Number){
    return this.http.delete<Student>('https://localhost:44354/api/StudentChange?id='+id);
  }
  getStudentsWithoutClass(){
    return this.http.get<Student[]>('https://localhost:44354/api/StudentChange/GetStudentsWithoutClass');
  }
  addClassToStudent(dto:AddClassToStudent){
    return this.http.put<Student>('https://localhost:44354/api/StudentChange', dto);
  }
  onDeleteFromClass(id:Number){
    return this.http.get<Student>('https://localhost:44354/api/StudentChange/DeleteFromClass?id='+id);
  }
  getOneStudentToEdit(id:Number){
    return this.http.get<StudentToEdit>('https://localhost:44354/api/StudentChange/GetToEdit?id='+id);
  }
  EditStudent(studentToEdit: StudentToEdit){
    return this.http.put<Student>('https://localhost:44354/api/StudentChange/EditStudent', studentToEdit);
  }
}
