import { Component, OnInit } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';
import { Artist$ } from 'src/app/_services/artist.service/artist.subject.service';
import { distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-artist-edit',
  templateUrl: './artist-edit.component.html',
  styleUrls: ['./artist-edit.component.css'],
})
export class ArtistEditComponent implements OnInit {
  artist: Artist;

  constructor(private route: ActivatedRoute, private _artist$: Artist$) {}

  ngOnInit() {
    this.getArtist();
    this.watchArtist();
  }

  watchArtist() {
    this._artist$.artist$.pipe(distinctUntilChanged()).subscribe((artist) => {
      this.artist = artist;
    });
  }

  getArtist() {
    this.route.data
      .subscribe((data) => {
        this._artist$.update({ artist: data['artist'] });
      })
      .unsubscribe();
  }
}
