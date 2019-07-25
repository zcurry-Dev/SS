import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ArtistService } from '../../services/artistService.service'

@Component({
  templateUrl: './fetchArtist.component.html'
})

export class FetchArtistComponent {
  public artistList: ArtistData[];

  constructor(public http: Http, private _router: Router, private _artistService: ArtistService) {
    this.getArtists();
  }

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
  artistStatusId: number;
  careerBeginDate: Date;
  createdDate: Date;
}  
