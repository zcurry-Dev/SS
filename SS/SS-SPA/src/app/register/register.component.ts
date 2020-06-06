import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  FormGroupDirective,
  NgForm,
} from '@angular/forms';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ErrorStateMatcher } from '@angular/material/core';
import { AuthApiService } from '../_services/auth.service/auth.api.service';
import { AuthService } from '../_services/auth.service/auth.subject.service';
import { map } from 'rxjs/operators';

export class CrossFieldErrorMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    return control.touched && form.invalid;
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  matcher = new CrossFieldErrorMatcher();
  user: User;
  registerForm = this.fb.group(
    {
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
      ]),
      confirmPassword: new FormControl('', [Validators.required]),
    },
    { validator: this.passwordMatchValidor }
  );

  constructor(
    private _authApiService: AuthApiService,
    private _authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {}

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this._authApiService.Register(this.user).subscribe(
        () => {
          this.alertify.success('Registration successful');
        },
        (error) => {
          this.alertify.error(error);
        },
        () => {
          this._authApiService
            .Login(this.user)
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
            .subscribe(() => {
              this.router.navigate(['/artist']);
            });
        }
      );
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  passwordMatchValidor(g: FormGroup) {
    return g.controls.password.value === g.controls.confirmPassword.value
      ? null
      : { mismatch: true };
  }
}
