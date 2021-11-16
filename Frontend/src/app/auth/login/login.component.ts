import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  errors!: string[];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: [
        'test@mail.com',
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
        ],
      ],
      password: ['Ab#123456', Validators.required],
    });
  }

  onSubmit() {
    this.authService.register(this.loginForm.value).subscribe(
      (response) => {
        this.router.navigateByUrl('/');
      },
      (error) => {
        console.log(error);
        this.errors = error.error.errors;
      }
    );
  }
}
