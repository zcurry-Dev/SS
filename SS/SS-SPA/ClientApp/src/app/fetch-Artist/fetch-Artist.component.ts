import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ArtistService } from '../services/artistService.service'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-Artist.component.html'
})
export class FetchArtistComponent {
  public artistList: ArtistData[];

  constructor(public http: Http, private _router: Router, private _artistService: ArtistService) {
    this.getArtists();
  } 

  //constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private _artistService: ArtistService) {
  //  http.get<ArtistData[]>(baseUrl + 'api/Artist/Index').subscribe(result => {
  //    this.artistList = result;
  //  },
  //    error => console.error(error));
  //}

  getArtists() {
    this._artistService.getArtists().subscribe(
      data => this.artistList = data
    )
  }

  delete(artistID) {
    var ans = confirm("Do you want to delete customer with Id: " + artistID);
    if (ans) {
      this._artistService.deleteArtist(artistID).subscribe((data) => {
        this.getArtists();
      }, error => console.error(error))
    }
  } 
}

interface ArtistData {
  artistId: number;
  artistName: string;
  careerBeginDate: Date;
  createdDate: Date;
}  
