import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-canvas',
  templateUrl: './dashboard-canvas.component.html',
})
export class DashboardCanvasComponent implements OnInit {
  @Input() title: any = 'Doctor';
  @Input() percent = 50;
  public subtitle: any;
  constructor() {}

  ngOnInit(): void {
    this.subtitle = this.formatSubtitle(this.percent);
  }

  private formatSubtitle = (percent: number): string => {
    if (percent >= 100) {
      return 'Congratulations!';
    } else if (percent >= 50) {
      return 'Half';
    } else if (percent > 0) {
      return 'Just began';
    } else {
      return 'Not started';
    }
  }
}
