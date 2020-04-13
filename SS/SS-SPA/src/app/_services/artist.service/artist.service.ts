import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Artist } from '../../_models/artist';
import { ImageService } from '../image.service/images.service';
import { SafeHtml, SafeUrl } from '@angular/platform-browser';
import { error } from 'protractor';
import { PaginatedResult } from 'src/app/_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ArtistService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private imageService: ImageService) {}

  getArtists(page?, itemsPerPage?): Observable<PaginatedResult<Artist[]>> {
    const paginatedResult: PaginatedResult<Artist[]> = new PaginatedResult<
      Artist[]
    >();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pn', page);
      params = params.append('ps', itemsPerPage);
    }

    return this.http
      .get<Artist[]>(this.baseUrl + 'artists', { observe: 'response', params })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        })
      );
  }

  getArtist(id): Observable<Artist> {
    return this.http.get<Artist>(this.baseUrl + 'artists/' + id);
  }

  updateArtist(id: number, artist: Artist) {
    return this.http.put(this.baseUrl + 'artists/' + id, artist);
  }

  getArtistPhoto(photoId: number): Observable<Blob> {
    const path = this.baseUrl + 'artists/getArtistPhoto/' + photoId;
    return this.imageService.getImage(path);
  }

  setMainPhoto(artistId: number, photoId: number) {
    return this.http.post(
      this.baseUrl + 'artists/' + artistId + '/photos/' + photoId + '/setMain',
      {}
    );
  }

  deletePhoto(artistId: number, photoId: number) {
    return this.http.delete(
      this.baseUrl + 'artists/' + artistId + '/photos/' + photoId
    );
  }
}
