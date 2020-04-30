import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ArtistPhoto } from 'src/app/_models/artistPhoto';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Artist } from 'src/app/_models/artist';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent implements OnInit {
  @Input() artist: Artist;
  @Output() getArtistPhotoChange = new EventEmitter<SafeUrl>();
  photos: ArtistPhoto[];
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  response: string;
  baseUrl = environment.apiUrl;
  currentMain: ArtistPhoto;

  constructor(
    private artistService: ArtistService,
    private imageService: ImageService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.photos = this.artist.photos;
    for (const photo of this.photos) {
      this.artistService.getArtistPhoto(photo.id).subscribe((image) => {
        photo.photoURL = this.imageService.sanitizeImage(image);
      });
    }

    this.initializeUploader();
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'artist/' + this.artist.id + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = async (item, response, status, headers) => {
      if (response) {
        const res: ArtistPhoto = JSON.parse(response);
        this.setPhotoURL(res);
      }
    };
  }

  setPhotoURL(res) {
    this.artistService.getArtistPhoto(res.id).subscribe((image) => {
      res.photoURL = this.imageService.sanitizeImage(image);

      // would prefer to move back into initializeUploader
      //
      const photo = {
        id: res.id,
        description: res.description,
        dateAdded: res.dateAdded,
        isMain: res.isMain,
        photoURL: res.photoURL,
      };
      this.photos.push(photo);
      if (photo.isMain) {
        // // set photo
        // this.authService.changeArtistPhoto(photo.url);
        // this.authService.currentUser.photoURL = photo.photoURL;
        // localStorage.setItem('user', JSON.stringify(THIS.authService.currentUser));
      }
      //
      //
    });
  }

  setMainPhoto(photo: ArtistPhoto) {
    this.artistService.setMainPhoto(this.artist.id, photo.id).subscribe(
      () => {
        this.currentMain = this.photos.filter((p) => p.isMain === true)[0];
        this.currentMain.isMain = false;
        photo.isMain = true;
        this.getArtistPhotoChange.emit(photo.photoURL);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  deletePhoto(photoId: number) {
    this.alertify.confirm('Are you sure you want to delete this photo?', () => {
      this.artistService.deletePhoto(this.artist.id, photoId).subscribe(
        () => {
          this.photos.splice(
            this.photos.findIndex((p) => p.id === photoId),
            1
          );
          this.alertify.success('Photo has been deleted');
        },
        (error) => {
          this.alertify.error('Failed to delete photo');
        }
      );
    });
  }
}
