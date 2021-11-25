import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
    selector: 'app-authorize-view',
    templateUrl: './authorize-view.component.html',
    styleUrls: ['./authorize-view.component.css'],
})
export class AuthorizeViewComponent implements OnInit {
    constructor(private authService: AuthService) {}

    ngOnInit(): void {}

    @Input()
    role!: string;

    public isAuthorized() {
        if (this.role) {
            return this.authService.getRole() === this.role;
        }

        return this.authService.isAuthenticated();
    }
}
