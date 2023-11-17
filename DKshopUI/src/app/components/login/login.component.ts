import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,FormControl,Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup | any;
  title = 'material-login';
  constructor(private fb:FormBuilder,private router:Router) {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required,Validators.pattern(
        'admin@123',
      ),]),
      password: new FormControl('', [Validators.required,Validators.pattern(
        'admin@321'
      )])
    });
  }

  ngOnInit(): void {
    // this.createForm()

  }
  // createForm(){
  //   this.LoginForm = this.fb.group({
  //     email:[''],
  //     password:['']
  //   })
  // }

  // signIn(){
  //   console.log("values",this.LoginForm.value.email, 'Password',this.LoginForm.value.password)
  // }
  // createAccount(){

  // }

  onSubmit(){
    if(!this.loginForm.valid){
      return;
    }
    localStorage.setItem('user',this.loginForm.value)
    this.router.navigate(['/adminPanel'])
  }

}
