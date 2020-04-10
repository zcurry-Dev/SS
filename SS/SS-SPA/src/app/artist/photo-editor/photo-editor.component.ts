import { Component, OnInit, Input } from '@angular/core';
import { ArtistPhoto } from 'src/app/_models/artistPhoto';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ImageService } from 'src/app/_services/images.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Artist } from 'src/app/_models/artist';
import { SafeUrl } from '@angular/platform-browser';
import { resolve } from 'dns';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent implements OnInit {
  @Input() artist: Artist;
  photos: ArtistPhoto[];
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  response: string;
  baseUrl = environment.apiUrl;

  constructor(
    private artistService: ArtistService,
    private imageService: ImageService
  ) {
    // this.response = '';
    // this.uploader.response.subscribe((res) => (this.response = res));
  }

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
      url: this.baseUrl + 'artists/' + this.artist.id + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
      // disableMultipart: true, // 'DisableMultipart' must be 'true' for formatDataFunction to be called.
      // formatDataFunctionIsAsync: true,
      // formatDataFunction: async (item) => {
      //   return new Promise((resolve, reject) => {
      //     resolve({
      //       name: item._file.name,
      //       length: item._file.size,
      //       contentType: item._file.type,
      //       date: new Date(),
      //     });
      //   });
      // },
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

      const photo = {
        id: res.id,
        description: res.description,
        dateAdded: res.dateAdded,
        isMain: res.isMain,
        photoURL: res.photoURL,
      };

      this.photos.push(photo);
    });
  }
}
