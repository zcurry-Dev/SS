import { Component, OnInit } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation
} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css']
})
export class ArtistDetailComponent implements OnInit {
  artist: Artist;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private artistService: ArtistService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.artist = data['artist'];
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.artist.photos) {
      imageUrls.push({
        small: photo.photoUrl,
        medium: photo.photoUrl,
        big: photo.photoUrl,
        description: photo.description
      });
    }
    return imageUrls;
  }
}
