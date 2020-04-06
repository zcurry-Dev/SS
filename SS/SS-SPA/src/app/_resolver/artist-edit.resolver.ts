import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Artist } from '../_models/artist';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { ArtistService } from '../_services/artist.service/artist.service';

@Injectable()
export class ArtistEditResolver implements Resolve<Artist> {
  constructor(
    private artistService: ArtistService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Artist> {
    return this.artistService.getArtist(route.params['id']).pipe(
      catchError(error => {
        this.alertify.error("Problem retrieving a specific artist's data");
        this.router.navigate(['/artists']);
        return of(null);
      })
    );
  }
}
