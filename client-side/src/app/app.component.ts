import { Component, OnInit } from '@angular/core';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';
import { ChatService } from './shared/services/chat.service';
import { AuthComponent } from './views/auth/auth.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  private user!: User;
  title = 'Doccure';

  constructor(private auth: AuthService, private chatService: ChatService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }

  private setCurrentUser() {
    this.user = this.auth.checkUser();

    if (this.user) {
      this.auth.setCurrentUser(this.user);
      this.chatService.createHubConnection(this.user);
    }
  }
}
