import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthenticationService } from 'src/services/authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    const currentUser = this.authenticationService.currentUserValue;

    if (currentUser && state.url === "/") {
      // logged and redirect
      this.router.navigate(['/dashboard']);
    }
    else if (currentUser) {
      // logged in so return true
      return true;
    }
    else if (!currentUser && state.url !== "/") {
      this.router.navigate(['/']);
      return true;
    }
    return true;
  }
}
