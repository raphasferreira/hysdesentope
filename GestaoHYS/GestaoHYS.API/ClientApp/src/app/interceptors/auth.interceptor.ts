import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

@Injectable()

export class AuthInterceptor implements HttpInterceptor{
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage.getItem("token");

        if(token)
        {
           const cloned = request.clone({
               headers: request.headers.set('Authorization',
               'Bearer ' + token)

           });     
           return next.handle(cloned);
        }

        return next.handle(request).pipe(tap(
            (httpEvent: any) => { },
            (err: any) => {
                if(err instanceof HttpErrorResponse){
                    if(err.status === 401) {
                        localStorage.clear();
                    }
                }
            }

        ))

    }

}