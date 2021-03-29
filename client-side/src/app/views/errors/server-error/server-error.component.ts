import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html'
})
export class ServerErrorComponent implements OnInit {
  public error: any;

  constructor(private router: Router) { }

  ngOnInit(): void {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.error;
  }

}
