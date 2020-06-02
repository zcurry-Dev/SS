import { Component, OnInit, EventEmitter, Output, Inject } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Artist } from 'src/app/_models/artist';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';

@Component({
  selector: 'app-artist-add',
  templateUrl: './artist-add.component.html',
  styleUrls: ['./artist-add.component.css'],
})
export class ArtistAddComponent implements OnInit {
  addArtistForm = this.fb.group({
    name: new FormControl('', [Validators.required]),
  });

  constructor(
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router,
    private dialogRef: MatDialogRef<ArtistAddComponent>,
    private artistService: ArtistService
  ) {}

  ngOnInit() {}

  cancel() {
    this.dialogRef.close();
  }

  addArtist() {
    console.log('test');

    if (this.addArtistForm.valid) {
      const artist = Object.assign({}, this.addArtistForm.value);
      this.artistService.addArtist(artist).subscribe(
        (added: Artist) => {
          this.alertify.success('Added Artist successful');
          this.router.navigate(['/artist/edit', added.id]);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }
  }
}
