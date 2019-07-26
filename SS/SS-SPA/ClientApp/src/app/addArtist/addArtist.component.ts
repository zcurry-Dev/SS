import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchArtistComponent } from '../fetch-Artist/fetch-Artist.component';
import { ArtistService } from '../services/artistService.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  templateUrl: './addArtist.component.html'
})

export class CreateArtist implements OnInit {
  artistForm: FormGroup;
  title: string = "Create";
  artistId: number;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _artistService: ArtistService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.artistId = this._avRoute.snapshot.params["id"];
    }

    this.artistForm = this._fb.group({
      artistId: 0,
      artistName: ['', [Validators.required]],
      careerBeginDate : ['', [Validators.required]],
      createdDate: ['', [Validators.required]]
    })
  }

  ngOnInit() {
    if (this.artistId > 0) {
      this.title = "Edit";
      this._artistService.getArtistById(this.artistId)
        .subscribe(resp => this.artistForm.setValue(resp)
          , error => this.errorMessage = error);
    }
  }

  save() {
    if (!this.artistForm.valid) {
      return;
    }

    if (this.title == "Create") {
      this._artistService.saveArtist(this.artistForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-artist']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._artistService.updateArtist(this.artistForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-artist']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/fetch-artist']);
  }

  get artistName() { return this.artistForm.get('artistName'); }
  get careerBeginDate() { return this.artistForm.get('careerBeginDate'); }
  get createdDate() { return this.artistForm.get('createdDate'); }
}  
