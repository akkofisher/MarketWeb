import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/user';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  currentUser: User;
  title='app';

  constructor(
      private router: Router,
      private authenticationService: AuthenticationService
  ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
      this.authenticationService.logout();
      this.router.navigate(['/']);
  }


}
