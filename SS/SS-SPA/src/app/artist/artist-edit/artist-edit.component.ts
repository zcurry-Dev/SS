import { Component, OnInit } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-artist-edit',
  templateUrl: './artist-edit.component.html',
  styleUrls: ['./artist-edit.component.css'],
})
export class ArtistEditComponent implements OnInit {
  artist: Artist;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.getArtist();
  }

  private getArtist() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
    });
  }
}
