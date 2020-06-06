import { Component, OnInit, Output, EventEmitter, Inject } from '@angular/core';
import { User } from 'src/app/_models/user';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AuthService } from 'src/app/_services/auth.service/auth.subject.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css'],
})
export class RolesModalComponent implements OnInit {
  @Output() updateSelectedRoles = new EventEmitter();
  user: User;
  roles: any[];

  constructor(
    private _authService: AuthService,
    @Inject(MAT_DIALOG_DATA) public data: { user: User; roles: any[] }
  ) {}

  ngOnInit() {
    this.setValues();
  }

  setValues() {
    this.user = this.data.user;
    this.roles = this.data.roles;
  }

  updateRoles() {
    this.updateSelectedRoles.emit(this.roles);
  }

  modalUserIsAdmin() {
    return this.user.roles.includes('Admin');
  }

  modalUserIsCurrentUser() {
    // this runs the amount of times the amount of roles availible
    // would be nice to make this only check once
    const nameId = this._authService.returnDecodedToken().nameid;
    return this.user.id === parseInt(nameId, 10);
  }
}
