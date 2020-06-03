import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  HostListener,
} from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import {
  FormControl,
  Validators,
  FormBuilder,
  FormGroup,
  NgForm,
  ReactiveFormsModule,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { map, filter, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  @Input() artist: Artist;
  editArtistAboutForm: FormGroup;
  name = new FormControl('', Validators.required);

  // editArtistAboutForm = FormGroup;
  // editArtistAboutForm = this.fb.group({
  //   name: new FormControl(this.artist.name, [Validators.required]),
  // });

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
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.editArtistAboutForm = this.fb.group({
      name: this.name,
    });
  }

  updateArtist() {
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
}
