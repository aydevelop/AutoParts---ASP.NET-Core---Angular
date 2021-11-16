import { Component, OnInit } from '@angular/core';
import {
  AsyncValidatorFn,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errors!: string[];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      userName: ['test', [Validators.required]],
      email: [
        'test@mail.com',
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
        ],
      ],
      site: [
        'http://localhost:4200/register',
        [
          Validators.required,
          Validators.pattern('^(.*:)//([A-Za-z0-9-.]+)(:[0-9]+)?(.*)$'),
        ],
      ],
      password: ['Ab#123456', Validators.required],
    });
  }

  onSubmit() {
    this.authService.register(this.registerForm.value).subscribe(
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
