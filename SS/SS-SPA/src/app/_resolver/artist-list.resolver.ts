import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Artist } from '../_models/artist';
import { ArtistApiService } from '../_services/artist.service/artist.api.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ArtistListResolver implements Resolve<Artist[]> {
  pn = 1;
  ipp = 10;
  search: string;

  constructor(
    private artistService: ArtistApiService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Artist[]> {
    return this.artistService.List(this.pn, this.ipp, this.search).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
