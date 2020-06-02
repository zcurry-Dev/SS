import {
  Component,
  OnInit,
  ViewChild,
  HostListener,
  Input,
  Output,
} from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { FormControl, Validators, FormBuilder } from '@angular/forms';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';

@Component({
  selector: 'app-artist-edit',
  templateUrl: './artist-edit.component.html',
  styleUrls: ['./artist-edit.component.css'],
})
export class ArtistEditComponent implements OnInit {
  @Input() artist: Artist;
  // @Input() editArtistForm;

  constructor(private route: ActivatedRoute, private fb: FormBuilder) {}

  ngOnInit() {
    this.getArtist();
  }

  // updateArtist() {
  //   this.artistService.updateArtist(this.artist.id, this.artist).subscribe(
  //     (next) => {
  //       this.alertify.success('Artist updated successfully');
  //       this.editArtistForm.reset(this.artist);
  //       this.router.navigate(['/artist', this.artist.id]);
  //     },
  //     (error) => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }

  private getArtist() {
    this.route.data.subscribe((data) => {
      this.artist = data['artist'];
    });

    // if (this.artist.mainPhotoId > 0) {
    //   this.artistService
    //     .getPhotoFile(this.artist.mainPhotoId)
    //     .subscribe((image) => {
    //       this.artist.mainPhotoURL = this.imageService.sanitizeImage(image);
    //     });
    // }
  }

  // updateMainPhoto(photoUrl) {
  //   this.artist.mainPhotoURL = photoUrl;
  // }
}
