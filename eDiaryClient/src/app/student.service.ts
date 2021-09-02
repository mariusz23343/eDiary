import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { StudentAdd } from './add-student/add-student.component';
export interface Student{
  id:Number,
  name:string,
  surname:string,
  date:Date,
  emailParent:string,
  pesel:string
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
}
