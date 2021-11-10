import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errors!: string[];

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      userName: ['', [Validators.required]],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),
        ],
      ],
      site: [
        '',
        [
          Validators.required,
          Validators.pattern('^((http|https)://)?www.([A-z]+).([A-z]{2,})/$'),
        ],
      ],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    alert(JSON.stringify(this.registerForm.value));
  }
}
