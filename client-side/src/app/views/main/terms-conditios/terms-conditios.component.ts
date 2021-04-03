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

  private getTerms() {
    this.api.getTerm().subscribe({
      next: (response: Term) => (this.term = response),
      error: (error: Error) => console.error(error),
      complete: () => console.log(),
    });
  }
}
