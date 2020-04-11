import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service/auth.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-default',
    };
    this.createRegisterForm();
  }

  register() {
    // this.authService.register(this.model).subscribe(
    //   () => {
    //     this.alertify.success('Registration successful');
    //   },
    //   (error) => {
    //     this.alertify.error(error);
    //   }
    // );
    console.log(this.registerForm.value);
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }

  passwordMatchValidor(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value
      ? null
      : { mismatch: true };
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        firstName: new FormControl('', Validators.required),
        lastName: new FormControl('', Validators.required),
        email: new FormControl('', Validators.required),
        dateOfBirth: new FormControl(null, Validators.required),
        userName: new FormControl('', Validators.required),
        password: new FormControl('', [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(8),
        ]),
        confirmPassword: new FormControl('', Validators.required),
      },
      { validator: this.passwordMatchValidor }
    );
  }
}
