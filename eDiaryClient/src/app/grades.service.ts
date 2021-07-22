import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
export interface Grade{
  id:number,
  mark:number,
  subject:string,
}
@Injectable({
  providedIn: 'root'
})
export class GradesService {

  constructor(private http:HttpClient) { }
  getOneStudentsGrades(studentId:number):Observable<Grade[]>{
    return this.http.get<Grade[]>('https://localhost:44354/api/GradeStudent/'+studentId);//pobranie ocen jednego ucznia
  }
}
