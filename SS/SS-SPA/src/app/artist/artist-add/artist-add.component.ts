import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';

@Component({
  selector: 'app-artist-add',
  templateUrl: './artist-add.component.html',
  styleUrls: ['./artist-add.component.css'],
})
export class ArtistAddComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  artistForm: FormGroup;

  constructor(
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.createArtistForm();
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }

  createArtistForm() {
    this.artistForm = this.fb.group(
      {
        //   firstName: new FormControl('', Validators.required),
        //   lastName: new FormControl('', Validators.required),
        //   email: new FormControl('', Validators.required),
        //   // dateOfBirth: new FormControl(),
        //   // dateOfBirth: new FormControl(null, Validators.required),
        //   userName: new FormControl('', Validators.required),
        //   password: new FormControl('', [
        //     Validators.required,
        //     Validators.minLength(4),
        //     Validators.maxLength(8),
        //   ]),
        //   confirmPassword: new FormControl('', Validators.required),
      }
      // { validator: this.passwordMatchValidor }
    );
  }
}
