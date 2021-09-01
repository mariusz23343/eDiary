import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface ClassList{
  id:number,
  className:string,
  schoolYear:string,

}
@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  constructor(private http:HttpClient) { }

  getClasses():Observable<ClassList[]>{
    return this.http.get<ClassList[]>('https://localhost:44354/api/SchoolClass');
  }
}
