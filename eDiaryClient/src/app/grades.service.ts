import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
export interface Grade{
  id?:number,
  mark:number,
  studentId:number,
  subjectId:number,
  subjectName:string
}
@Injectable({
  providedIn: 'root'
})
export class GradesService {

  private actualisation: BehaviorSubject<string> = new BehaviorSubject<string>('');
  constructor(private http:HttpClient) { }
  getOneStudentsGrades(studentId:number):Observable<Grade[]>{
    return this.http.get<Grade[]>('https://localhost:44354/api/GradeStudent/id?id='+studentId);//pobranie ocen jednego ucznia
  }
  addGrade(grade:Grade, id:number){
    console.log(grade)
    return this.http.post<Grade>('https://localhost:44354/api/GradeStudent?id='+id, grade).pipe(tap(
      res=>this.actualisation.next('dodano studenta')
    ));
  }
  deleteGrade(gradeId:number){
    return this.http.delete('https://localhost:44354/api/GradeStudent?id='+gradeId)
  }
}
