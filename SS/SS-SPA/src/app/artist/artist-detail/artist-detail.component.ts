import { Component, OnInit, SecurityContext, Output } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css'],
})
export class ArtistDetailComponent implements OnInit {
  @Output() artist: Artist;
  followArtist = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
      console.log('this.artist', this.artist);
    });
  }

  follow() {
    this.followArtist = true;
  }
}
