import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../_models/user';
import { AdminApiService } from '../_services/admin.service/admin.api.service';

@Injectable()
export class AdminUsersResolver implements Resolve<User[]> {
  pn = 1;
  ipp = 10;
  search: string;

  constructor(
    private _adminApiService: AdminApiService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
    return this._adminApiService.ListUsers(this.pn, this.ipp, this.search).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
