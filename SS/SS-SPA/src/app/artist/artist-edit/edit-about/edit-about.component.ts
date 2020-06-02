import { Component, OnInit, Input, Output } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ArtistService } from 'src/app/_services/artist.service/artist.service';
import {
  FormControl,
  Validators,
  FormBuilder,
  FormGroup,
  NgForm,
} from '@angular/forms';

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  @Input() artist: Artist;
  editArtistAboutForm = this.fb.group({
    name: new FormControl('', [Validators.required]),
  });

  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private artistService: ArtistService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {}

  updateArtist() {
    this.artistService.updateArtist(this.artist.id, this.artist).subscribe(
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
}
