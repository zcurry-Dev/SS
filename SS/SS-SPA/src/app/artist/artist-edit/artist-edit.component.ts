import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { NgForm } from '@angular/forms';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { Country } from 'src/app/_models/countries';

@Component({
  selector: 'app-artist-edit',
  templateUrl: './artist-edit.component.html',
  styleUrls: ['./artist-edit.component.css'],
})
export class ArtistEditComponent implements OnInit {
  @ViewChild('editArtistForm', { static: true }) editArtistForm: NgForm;
  selectedValue: string;

  artist: Artist;
  usArtist = [
    { value: 'true', viewValue: 'yes' },
    { value: 'false', viewValue: 'no' },
  ];
  // usArtist2 = this.usArtist.value;

  countries: Country[];

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editArtistForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private artistService: ArtistService,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.getArtist();
  }

  updateArtist() {
    this.artistService.updateArtist(this.artist.id, this.artist).subscribe(
      (next) => {
        this.alertify.success('Artist updated successfully');
        this.editArtistForm.reset(this.artist);
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

    if (this.artist.mainPhotoId > 0) {
      this.artistService
        .getPhotoFile(this.artist.mainPhotoId)
        .subscribe((image) => {
          this.artist.mainPhotoURL = this.imageService.sanitizeImage(image);
        });
    }
  }

  updateMainPhoto(photoUrl) {
    this.artist.mainPhotoURL = photoUrl;
  }
}
