import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Artist } from '../../_models/artist';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getArtists(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.baseUrl + 'artists');
  }

  getArtist(id): Observable<Artist> {
    return this.http.get<Artist>(this.baseUrl + 'artists/' + id);
  }

  updateArtist(id: number, artist: Artist) {
    return this.http.put(this.baseUrl + 'artists/' + id, artist);
  }
}
