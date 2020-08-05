import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Router } from '@angular/router';
import { AuthApiService } from '../_services/auth.service/auth.api.service';
import { AuthService } from '../_services/auth.service/auth.subject.service';
import { distinctUntilChanged, tap } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  decodedToken: any;

  constructor(
    private _authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {
    this.watchLoggedIn();
  }

  loggedIn() {
    return this._authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this._authService.update({ decodedToken: null });
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }

  watchLoggedIn() {
    this._authService.decodedToken$.pipe(distinctUntilChanged()).subscribe(
      (decodedToken) => {
        this.decodedToken = decodedToken;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
