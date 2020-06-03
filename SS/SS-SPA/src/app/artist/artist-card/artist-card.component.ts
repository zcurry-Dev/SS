import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { NgForm, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css'],
})
export class ArtistCardComponent implements OnInit {
  @Input() artist: Artist;
  @Input() edit: boolean;
  // @Input() editArtistForm: FormGroup;
  followArtist = false;
  editMode = true;

  constructor(
    private artistService: ArtistApiService,
    private imageService: ImageService
  ) {}

  ngOnInit() {}

  follow() {
    this.followArtist = true;
  }
}
