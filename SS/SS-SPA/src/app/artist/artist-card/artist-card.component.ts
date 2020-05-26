import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css'],
})
export class ArtistCardComponent implements OnInit {
  @Input() artist: Artist;
  @Input() edit: boolean;
  @Input() editArtistForm: NgForm;
  followArtist = false;
  editMode = true;

  constructor(
    private artistService: ArtistService,
    private imageService: ImageService
  ) {}

  ngOnInit() {}

  follow() {
    this.followArtist = true;
  }
}
