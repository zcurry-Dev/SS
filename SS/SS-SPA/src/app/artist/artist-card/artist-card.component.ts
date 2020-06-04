import { Component, OnInit, Input } from '@angular/core';
import { Artist, initArtist } from 'src/app/_models/artist';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { NgForm, FormGroup } from '@angular/forms';
import { ArtistService } from 'src/app/_services/artist.service/artist.subject.service';
import { distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css'],
})
export class ArtistCardComponent implements OnInit {
  @Input() edit: boolean;
  artist: Artist;
  followArtist = false;
  editMode = true;

  constructor(private _artist: ArtistService) {}

  ngOnInit() {
    this.watchArtist();
  }

  watchArtist() {
    this._artist.artist$
      .pipe(distinctUntilChanged())
      .subscribe((artist) => (this.artist = artist || initArtist()));
  }

  follow() {
    this.followArtist = true;
  }
}
