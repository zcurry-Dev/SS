import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { NgForm } from '@angular/forms';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { AuthService } from 'src/app/_services/auth.service/auth.service';
import { ImageService } from 'src/app/_services/images.service';

@Component({
  selector: 'app-artist-edit',
  templateUrl: './artist-edit.component.html',
  styleUrls: ['./artist-edit.component.css'],
})
export class ArtistEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  artist: Artist;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private artistService: ArtistService,
    private authService: AuthService,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.getArtist();
  }

  updateArtist() {
    // this.artistService.updateArtist(this.authService.decodedToken.nameid, this.artist);
    this.artistService.updateArtist(this.artist.id, this.artist).subscribe(
      (next) => {
        this.alertify.success('Artist updated successfully');
        this.editForm.reset(this.artist);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  private getArtist() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
    });

    this.artistService
      .getArtistPhoto(this.artist.photoId)
      .subscribe((image) => {
        this.artist.mainPhotoURL = this.imageService.sanitizeImage(image);
      });
  }
}
