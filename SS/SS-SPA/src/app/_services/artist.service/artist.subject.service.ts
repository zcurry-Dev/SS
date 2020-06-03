// // import { Injectable } from '@angular/core';
// import { environment } from 'src/environments/environment';
// // import { HttpClient, HttpParams } from '@angular/common/http';
// // import { Observable, BehaviorSubject } from 'rxjs';
// import { Artist } from '../../_models/artist';
// import { ImageService } from '../image.service/images.service';
// import { PaginatedResult } from 'src/app/_models/pagination';
// import { map } from 'rxjs/operators';
// import { PhotoIds } from 'src/app/_models/photoIds';

// import { Injectable } from '@angular/core';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { catchError } from 'rxjs/operators';
// import { Observable, Subject } from 'rxjs';

// import { environment as env } from 'src/environments/environment';
// import { of, EMPTY } from 'rxjs';
// // import { Subject } from 'rxjs/Subject';
// import { User } from './admin.service';

// const API_URL = env.apiUrl + 'artist/';

// @Injectable({
//   providedIn: 'root',
// })
// export class ArtistService {
//   constructor(private http: HttpClient) {}

//   public Get(): Observable<Artist> {
//     const url = `${API_URL}/${env.userGetApi}`;
//     return this.http.get<User>(url).pipe(
//       catchError((error) => {
//         console.log(error);
//         return EMPTY;
//       })
//     );
//   }

//   getArtists(
//     page?,
//     itemsPerPage?,
//     search?
//   ): Observable<PaginatedResult<Artist[]>> {
//     const paginatedResult: PaginatedResult<Artist[]> = new PaginatedResult<
//       Artist[]
//     >();
//     let params = new HttpParams();

//     if (page != null && itemsPerPage != null) {
//       params = params.append('pn', page);
//       params = params.append('ps', itemsPerPage);
//     }

//     if (search) {
//       params = params.append('search', search);
//     }

//     return this.http
//       .get<Artist[]>(API_URL, { observe: 'response', params })
//       .pipe(
//         map((response) => {
//           paginatedResult.result = response.body;
//           if (response.headers.get('Pagination') != null) {
//             paginatedResult.pagination = JSON.parse(
//               response.headers.get('Pagination')
//             );
//           }
//           return paginatedResult;
//         })
//       );
//   }

//   getArtist(id: number): Observable<Artist> {
//     return this.http.get<Artist>(API_URL + id);
//   }

//   addArtist(artist: {}) {
//     return this.http.post(API_URL + 'create', artist);
//   }

//   updateArtist(id: number, artist: Artist) {
//     // check to see if this passes only name currently
//     return this.http.patch(API_URL + id, artist);
//   }
// }
