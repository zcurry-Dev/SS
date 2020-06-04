import { Component, OnInit, Input, HostListener } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import { FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, filter, switchMap, distinctUntilChanged } from 'rxjs/operators';
import { ArtistService } from 'src/app/_services/artist.service/artist.subject.service';

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  @Input() artist: Artist;
  editArtistAboutForm = this.fb.group({
    name: new FormControl(this.artist?.name, [Validators.required]),
  });

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editArtistAboutForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private alertify: AlertifyService,
    private artistService: ArtistApiService,
    private router: Router,
    private fb: FormBuilder,
    private _artist: ArtistService
  ) {}

  ngOnInit() {
    this.watchArtist();
    this.setFormValues();
  }

  updateArtist() {
    this.updateValues();
    this.artistService.Save(this.artist).subscribe(
      (next) => {
        this.alertify.success('Artist updated successfully');
        this.editArtistAboutForm.reset(this.artist);
        this.router.navigate(['/artist', this.artist.id]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  setFormValues() {
    this.editArtistAboutForm.patchValue(this.artist);
  }

  updateValues() {
    this.artist.name = this.editArtistAboutForm.value.name;
  }

  watchArtist() {
    this._artist.artist$.pipe(distinctUntilChanged()).subscribe((artist) => {
      this.artist = artist;
    });
  }
}
