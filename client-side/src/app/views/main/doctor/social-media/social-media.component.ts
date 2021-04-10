import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { DoctorService } from 'src/app/shared/services/doctor.service';
import { ToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-social-media',
  templateUrl: './social-media.component.html',
})
export class SocialMediaComponent implements OnInit {
  public fg: FormGroup = new FormGroup({});

  constructor(
    private title: Title,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private doctorService: DoctorService
  ) {}

  ngOnInit(): void {
    this.getUrls();
    this.title.setTitle('Doccure | Doctor Social Medial Url');
    this.intitializeForm();
  }

  private getUrls() {
    this.doctorService.getDoctorSocialMediaUrl().forEach((response) => {
      this.fg.controls.facebookURL.setValue(response.facebookURL);
      this.fg.controls.twitterURL.setValue(response.twitterURL);
      this.fg.controls.instagramURL.setValue(response.instagramURL);
      this.fg.controls.pinterestURL.setValue(response.pinterestURL);
      this.fg.controls.linkedinURL.setValue(response.linkedinURL);
    });
  }

  intitializeForm() {
    this.fg = this.fb.group({
      facebookURL: new FormControl('', Validators.required),
      twitterURL: new FormControl('', Validators.required),
      instagramURL: new FormControl('', Validators.required),
      pinterestURL: new FormControl('', Validators.required),
      linkedinURL: new FormControl('', Validators.required),
    });
  }

  public updateUrls() {
    this.doctorService
      .updateDoctorSocialMediaUrl(this.fg.value)
      .forEach((response) => this.toastr.success(response.message, 'Success'));
  }
}
