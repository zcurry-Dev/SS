import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../_services/auth.service/auth.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Router } from '@angular/router';
import { User } from '../_models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  // @Input() error: string | null;

  // @Output() submitEM = new EventEmitter();

  loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  // constructor() {}

  // submit() {
  //   if (this.form.valid) {
  //     this.submitEM.emit(this.form.value);
  //   }
  // }

  // ngOnInit() {}

  constructor(
    public authService: AuthService,
    private alterify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  login() {
    if (this.loginForm.valid) {
      const user: User = Object.assign({}, this.loginForm.value);
      this.authService.login(user).subscribe(
        (next) => {
          this.alterify.success('Logged in successfully');
        },
        (error) => {
          this.alterify.error(error);
        },
        () => {
          this.router.navigate(['/artist']);
        }
      );

      // this.authService.register(this.user).subscribe(
      //   () => {
      //     this.alertify.success('Registration successful');
      //   },
      //   (error) => {
      //     this.alertify.error(error);
      //   },
      //   () => {
      //     this.authService.login(this.user).subscribe(() => {
      //       this.router.navigate(['/artist']);
      //     });
      //   }
      // );
    }

    // this.authService.login(this.model).subscribe(
    //   (next) => {
    //     this.alterify.success('Logged in successfully');
    //   },
    //   (error) => {
    //     this.alterify.error(error);
    //   },
    //   () => {
    //     this.router.navigate(['/artist']);
    //   }
    // );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.authService.decodedToken = null;
    this.alterify.message('logged out');
    this.router.navigate(['/home']);
  }
}
