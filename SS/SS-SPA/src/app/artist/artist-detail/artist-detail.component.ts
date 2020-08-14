import { Component, OnInit, SecurityContext, Output } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';
import { Artist$ } from 'src/app/_services/artist.service/artist.subject.service';
import { distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css'],
})
export class ArtistDetailComponent implements OnInit {
  artist: Artist;
  followArtist = false;

  constructor(private _artist$: Artist$, private route: ActivatedRoute) {}

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

  follow() {
    this.followArtist = true;
  }
}
