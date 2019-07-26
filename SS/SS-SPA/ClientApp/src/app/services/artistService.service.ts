import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { HttpClientModule } from '@angular/common/http';

@Injectable()
export class ArtistService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getArtists() {
    return this._http.get(this.myAppUrl + 'api/Artists/Index')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  } 

  getArtistById(id: number) {
    return this._http.get(this.myAppUrl + "api/Artist/Details/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  saveArtist(artist) {
    return this._http.post(this.myAppUrl + 'api/Artist/Create', artist)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  updateArtist(artist) {
    return this._http.put(this.myAppUrl + 'api/Artist/Edit', artist)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  deleteArtist(id) {
    return this._http.delete(this.myAppUrl + "api/Artist/Delete/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
  
  errorHandler(error: Response) {
    console.log('Error:', error);
    return Observable.throw(error);
  }
}  
