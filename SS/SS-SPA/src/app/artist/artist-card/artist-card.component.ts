import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
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
      // .subscribe((artist) => (this.artist = artist || initArtist()));
      .subscribe((artist) => (this.artist = artist));
  }

  follow() {
    this.followArtist = true;
  }
}
