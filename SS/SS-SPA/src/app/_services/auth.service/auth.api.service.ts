import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment as env } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { EMPTY } from 'rxjs';

const API_URL = env.apiUrl + '/auth/';

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  constructor(private http: HttpClient) {}

  Login(model: any) {
    const url = `${env.apiUrl}/${env.authLogin}`;
    return this.http.post<User>(url, model).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  Register(user: User) {
    const url = `${env.apiUrl}/${env.authRegister}`;
    return this.http.post(url, user).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }
}
