import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-my-patients',
  templateUrl: './my-patients.component.html'
})
export class MyPatientsComponent implements OnInit {
  @Input() patients: User[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
