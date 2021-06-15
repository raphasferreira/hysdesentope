import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  @Output() isAuthenticated: BehaviorSubject<boolean> = new BehaviorSubject(true);

  constructor(private http: HttpClient, private routes: ActivatedRoute) { }
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })
    
  // login(username: string, password: string): Observable<any> {
  //   const body: any = {
  //     "username": username,
  //     "password": password
  //   };
  //   return this.http.post(this.urlLogin, body, {observe: "response",});
  // }

//   login(username: string, password: string): Observable<any> {
//     return this.http
//         .get(`${this.urlLogin}/${username}/${password}`, { observe: "response"})
// }

public login(email:string, senha:string): Observable<any> {
  return this.http.get(`${environment.API}Usuario/Login?email=${email}&senha=${senha}`, { observe: "response" })
}

validaSessao(){
  let token = localStorage.getItem("token");
  if(token == null || token == '' || token == 'undefined'){
    return false;
  }
  return true;
}
}
