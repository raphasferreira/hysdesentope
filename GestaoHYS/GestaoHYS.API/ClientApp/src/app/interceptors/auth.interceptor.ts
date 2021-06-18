import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { CommomService } from "../services/commom.service";

@Injectable()

export class AuthInterceptor implements HttpInterceptor{

    constructor(private router: Router) { }


    private handleAuthError(err: HttpErrorResponse): Observable<any> {

        //handle your auth error or rethrow
        if (err.status === 401 || err.status === 403) {
            localStorage.clear();
            this.router.navigate(['/login']);
        }
        return throwError(err);
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage.getItem("token");

        if(token)
        {
           const cloned = request.clone({
               headers: request.headers.set('Authorization',
               'Bearer ' + token)

           });     
           return next.handle(cloned).pipe(catchError(x=> this.handleAuthError(x)));
        }
        return next.handle(request).pipe(catchError(x=> this.handleAuthError(x)));
    }

}