import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
export interface Student{
  id:Number,
  name:string,
  surname:string,
  date:Date,
  email:string,
  pesel:string
}
@Injectable({
  providedIn: 'root'
})
export class ShowStudentService {

  constructor(private http:HttpClient) { }
  getStudents(classId:number){
    return this.http.get<Student[]>()
  }
}
