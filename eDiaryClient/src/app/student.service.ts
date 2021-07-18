import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
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

  constructor(private http:HttpClient) { }
  getStudents(classId:number):Observable<Student[]>{
    return this.http.get<Student[]>('https://localhost:44354/api/StudentChange/id?id='+classId);
  }
}
