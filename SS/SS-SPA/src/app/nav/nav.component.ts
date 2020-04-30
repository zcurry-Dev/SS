import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service/auth.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(
    public authService: AuthService,
    private alterify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
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
