import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Router } from '@angular/router';
import { AuthApiService } from '../_services/auth.service/auth.api.service';
import { AuthService } from '../_services/auth.service/auth.subject.service';
import { distinctUntilChanged, tap } from 'rxjs/operators';
import { UtilityApiService } from '../_services/utility.service/utility.api.service';
import { UtilityService } from '../_services/utility.service/utility.subject.service';
import { UsState } from '../_models/usState';

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
    private router: Router,
    private _utilityApi: UtilityApiService,
    private _utility: UtilityService
  ) {}

  ngOnInit() {
    this.watchLoggedIn();
    this.watchUtilities();
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

  watchUtilities() {
    this._utility.usCountry$.pipe(distinctUntilChanged()).subscribe((data) => {
      const myUsStates = JSON.parse(localStorage.getItem('usStates'));
      if (!myUsStates) {
        this.getUsStates();
      } else {
        this.setUSStatesObservable(myUsStates);
      }
    });
  }

  getUsStates() {
    this._utilityApi.ListUsStates().subscribe((usStates: UsState[]) => {
      this._utility.update({ usStates });
      localStorage.setItem('usStates', JSON.stringify(usStates));
    });
  }

  setUSStatesObservable(myUsStates) {
    this._utility.update({ usStates: myUsStates });
  }
}
