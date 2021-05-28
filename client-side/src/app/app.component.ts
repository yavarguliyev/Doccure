import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  private user!: User;
  private title = 'Doccure';

  constructor(
    private auth: AuthService,
    private router: Router,
    private titleService: Title
  ) {}

  ngOnInit(): void {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        this.titleService.setTitle(this.getNestedRouteTitles().join(' | '));
      });
    this.setCurrentUser();
  }

  private getNestedRouteTitles(): string[] {
    let currentRoute = this.router.routerState.root.firstChild;
    const titles: string[] = [];

    while (currentRoute) {
      if (currentRoute.snapshot.routeConfig.data?.title) {
        titles.push(currentRoute.snapshot.routeConfig.data.title);
      }

      currentRoute = currentRoute.firstChild;
    }

    return titles;
  }

  private setCurrentUser() {
    this.user = this.auth.checkUser();

    if (this.user) {
      this.auth.setCurrentUser(this.user);
    }
  }
}
