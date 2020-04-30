import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Artist } from '../../_models/artist';
import { ImageService } from '../image.service/images.service';
import { PaginatedResult } from 'src/app/_models/pagination';
import { map } from 'rxjs/operators';
import { PhotoIds } from 'src/app/_models/photoIds';

@Injectable({
  providedIn: 'root',
})
export class ArtistService {
  baseUrl = environment.apiUrl + 'artist/';

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
      .get<Artist[]>(this.baseUrl, { observe: 'response', params })
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

  getArtist(id: number): Observable<Artist> {
    return this.http.get<Artist>(this.baseUrl + id);
  }

  getPhotoFile(photoId: number): Observable<Blob> {
    const path = this.baseUrl + 'getPhotoFile/' + photoId;
    return this.imageService.getImage(path);
  }

  updateArtist(id: number, artist: Artist) {
    // check to see if this passes only name currently
    return this.http.put(this.baseUrl + id, artist);
  }

  getArtistPhoto(photoId: number) {
    return this.http.get(this.baseUrl + photoId);
  }

  // AddPhotoForArtist -- not implemented I don't believe
  addPhotoForArtist(photoId: number, photoForCreationDto: PhotoIds) {
    // want to pass photoForCreationDto in body and not PhotoIds
    return this.http.post(this.baseUrl + photoId, photoForCreationDto);
  }

  setMainPhoto(photoIds: PhotoIds) {
    return this.http.post(this.baseUrl + 'setMain', photoIds);
  }

  deletePhoto(photoIds: PhotoIds) {
    const url = this.baseUrl + 'deletePhoto';
    return this.http.request('delete', url, { body: photoIds });
  }
}
