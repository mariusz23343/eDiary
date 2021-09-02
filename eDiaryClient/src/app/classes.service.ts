import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AddClass } from './add-class/add-class.component';

export interface ClassList{
  id:number,
  className:string,
  schoolYear:string,

}
@Injectable({
  providedIn: 'root'
})
export class ClassesService {
  private actualisation: BehaviorSubject<string> = new BehaviorSubject<string>('');
  constructor(private http:HttpClient) { }

  getClasses():Observable<ClassList[]>{
    return this.http.get<ClassList[]>('https://localhost:44354/api/SchoolClass');
  }
  addClass(schoolClass:AddClass):Observable<AddClass>{
    return this.http.post<AddClass>('https://localhost:44354/api/SchoolClass', schoolClass).pipe(tap(
        res=>this.actualisation.next('dodano klase')
    ));
  }
}
