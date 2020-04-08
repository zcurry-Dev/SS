import { Component, OnInit } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation,
} from '@kolkov/ngx-gallery';
import { SafeUrl, DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css'],
})
export class ArtistDetailComponent implements OnInit {
  artist: Artist;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private artistService: ArtistService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
      this.artist.photoPath = '../uploadedImages/artists/1/myArcher.jpg';
      console.log(this.artist.photoPath);
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
      },
    ];
    this.galleryImages = this.getImages();
  }

  getlink(): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(this.artist.photoPath);
  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.artist.photos) {
      imageUrls.push({
        small: photo.photoPath,
        medium: photo.photoPath,
        big: photo.photoPath,
        description: photo.description,
      });
    }
    return imageUrls;
  }
}
