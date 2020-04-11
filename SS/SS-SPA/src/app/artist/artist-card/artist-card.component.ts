import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ImageService } from 'src/app/_services/image.service/images.service';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css'],
})
export class ArtistCardComponent implements OnInit {
  @Input() artist: Artist;

  constructor(
    private artistService: ArtistService,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.getMainImage();
  }

  getMainImage() {
    this.artistService
      .getArtistPhoto(this.artist.photoId)
      .subscribe((image) => {
        this.artist.mainPhotoURL = this.imageService.sanitizeImage(image);
      });
  }
}
