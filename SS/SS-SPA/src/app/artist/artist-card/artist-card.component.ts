import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/_models/artist';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css']
})
export class ArtistCardComponent implements OnInit {
  @Input() artist: Artist;

  constructor() {}

  ngOnInit() {}
}
