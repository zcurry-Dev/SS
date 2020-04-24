import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Artist } from '../_models/artist';
import { ArtistService } from '../_services/artist.service/artist.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../_models/user';
import { AdminService } from '../_services/admin.service/admin.service';

@Injectable()
export class AdminUsersResolver implements Resolve<User[]> {
  pn = 1;
  ps = 10;
  search: string;

  constructor(
    private adminService: AdminService,
    private artistService: ArtistService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
    return this.adminService
      .getUsersWithRoles(this.pn, this.ps, this.search)
      .pipe(
        catchError((error) => {
          console.log(error);
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/home']);
          return of(null);
        })
      );
  }
}
