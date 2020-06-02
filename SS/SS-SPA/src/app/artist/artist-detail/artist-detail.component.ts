import { Component, OnInit, SecurityContext, Output } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation,
} from '@kolkov/ngx-gallery';
import { ImageService } from 'src/app/_services/image.service/images.service';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css'],
})
export class ArtistDetailComponent implements OnInit {
  @Output() artist: Artist;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  isImageLoading = false;
  followArtist = false;

  constructor(
    private artistService: ArtistService,
    private route: ActivatedRoute,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
      console.log('this.artist', this.artist);
    });

    // this.getMainImage();

    // this.galleryOptions = [
    //   {
    //     width: '500px',
    //     height: '500px',
    //     imagePercent: 100,
    //     thumbnailsColumns: 4,
    //     imageAnimation: NgxGalleryAnimation.Slide,
    //     preview: false,
    //   },
    // ];
    // this.galleryImages = this.getImages();
  }

  // getImages() {
  //   const images = [];
  //   for (const photo of this.artist.photos) {
  //     this.artistService.getPhotoFile(photo.id).subscribe((image) => {
  //       photo.photoURL = this.imageService.sanitizeSecurityContextURL(image);
  //       images.push({
  //         small: photo.photoURL,
  //         medium: photo.photoURL,
  //         big: photo.photoURL,
  //         description: photo.description,
  //       });
  //     });
  //   }
  //   return images;
  // }

  // getMainImage() {
  //   if (this.artist.mainPhotoId > 0) {
  //     this.artistService
  //       .getPhotoFile(this.artist.mainPhotoId)
  //       .subscribe((image) => {
  //         this.artist.mainPhotoURL = this.imageService.sanitizeImage(image);
  //       });
  //   }
  // }

  follow() {
    this.followArtist = true;
  }
}
