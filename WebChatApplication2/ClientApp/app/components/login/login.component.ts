import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    constructor(private router: Router) { }

    signIn(nickname: any): void {
        if (!nickname.invalid) {
            sessionStorage.setItem("userName", nickname.value);
            this.router.navigateByUrl('/rooms');
        }
    }
}
