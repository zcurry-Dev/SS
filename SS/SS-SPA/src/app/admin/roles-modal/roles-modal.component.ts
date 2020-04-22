import { Component, OnInit, Output, EventEmitter, Inject } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service/auth.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css'],
})
export class RolesModalComponent implements OnInit {
  @Output() updateSelectedRoles = new EventEmitter();
  user: User;
  roles: any[];

  ngOnInit() {
    this.user = this.data.user;
    this.roles = this.data.roles;
  }

  constructor(
    private authService: AuthService,
    private dialogRef: MatDialogRef<RolesModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { user: User; roles: any[] }
  ) {}

  updateRoles() {
    this.updateSelectedRoles.emit(this.roles);
  }

  modalUserIsAdmin() {
    return this.user.roles.includes('Admin');
  }

  modalUserIsCurrentUser() {
    return this.user.id === parseInt(this.authService.decodedToken.nameid, 10);
  }
}
