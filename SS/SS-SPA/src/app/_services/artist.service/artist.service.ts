import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Artist } from '../../_models/artist';
import { ImageService } from '../images.service';
import { SafeHtml, SafeUrl } from '@angular/platform-browser';
import { error } from 'protractor';

@Injectable({
  providedIn: 'root',
})
export class ArtistService {
  baseUrl = environment.apiUrl;
  userPhotoUrl = new BehaviorSubject<string>(
    '../../../assets/fallbackUser.png'
  );
  currentPhotoUrl = this.userPhotoUrl.asObservable();

  constructor(private http: HttpClient, private imageService: ImageService) {}

  getArtists(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.baseUrl + 'artists');
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
