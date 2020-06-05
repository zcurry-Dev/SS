import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Artist } from '../_models/artist';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { ArtistApiService } from '../_services/artist.service/artist.api.service';

@Injectable()
export class ArtistEditResolver implements Resolve<Artist> {
  constructor(
    private _artist: ArtistApiService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Artist> {
    return this._artist.Get(route.params['id']).pipe(
      catchError((error) => {
        this.alertify.error("Problem retrieving a specific artist's data");
        this.router.navigate(['/artist']);
        return of(null);
      })
    );
  }
}
