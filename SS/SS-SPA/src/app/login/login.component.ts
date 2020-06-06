import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { AuthApiService } from '../_services/auth.service/auth.api.service';
import { AuthService } from '../_services/auth.service/auth.subject.service';
import { distinctUntilChanged, map, tap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private _authApiService: AuthApiService,
    private _authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  login() {
    if (this.loginForm.valid) {
      const user: User = Object.assign({}, this.loginForm.value);
      this._authApiService
        .Login(user)
        .pipe(
          map((response: any) => {
            if (response) {
              localStorage.setItem('token', response.token);
              const decodedToken = this._authService.decodeToken(
                response.token
              );
              this._authService.update({ decodedToken });
            }
          })
        )
        .subscribe(
          (next) => {
            this.alertify.success('Logged in successfully');
          },
          (error) => {
            this.alertify.error(error);
          },
          () => {
            this.router.navigate(['/artist']);
          }
        );
    }
  }
}
