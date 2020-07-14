import { Artist } from '../../_models/artist';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Observable, EMPTY } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ArtistApiService {
  constructor(private http: HttpClient) {}

  Get(id: number): Observable<Artist> {
    const url = `${env.apiUrl}/${env.artistGet}`;
    return this.http.get<Artist>(`${url}/${id}`).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  List(page?, itemsPerPage?, search?): Observable<PaginatedResult<Artist[]>> {
    const paginatedResult: PaginatedResult<Artist[]> = new PaginatedResult<
      Artist[]
    >();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pn', page);
      params = params.append('ipp', itemsPerPage);
    }

    if (search) {
      params = params.append('search', search);
    }

    const url = `${env.apiUrl}/${env.artistList}`;
    return this.http
      .get<Artist[]>(url, { observe: 'response', params })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        }),
        catchError((error) => {
          console.log(error);
          return EMPTY;
        })
      );
  }

  Create(artist: Artist): Observable<Artist> {
    const url = `${env.apiUrl}/${env.artistCreate}`;
    return this.http.post<Artist>(url, artist).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  Save(artist: Artist) {
    const url = `${env.apiUrl}/${env.artistSave}`;
    return this.http.patch<Artist>(`${url}/${artist.id}`, artist).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }
}
