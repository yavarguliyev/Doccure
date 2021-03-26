import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Term } from 'src/app/shared/models/term';
import { SettingsService } from 'src/app/shared/services/settings.service';

@Component({
  selector: 'app-terms-conditios',
  templateUrl: './terms-conditios.component.html'
})
export class TermsConditiosComponent implements OnInit {
  public term: Term | undefined;
  constructor(private api: SettingsService, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle('Doccure | Terms and Condition');
    this.getTerms();
  }

  getTerms() {
    this.api.getTermsAndCondition().subscribe((response) => this.term = response);
  }

}
