import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:51549/api';

  formModel = this.fb.group({
    UserName: ['',Validators.required],
    Email: ['',Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['',[Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['',Validators.required]
    }, { validators: this.comparePassword })
  });

  comparePassword( fb: FormGroup ){
    let confirmPswdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswdCtrl.errors=(passwordMismatch:true)
    if (confirmPswdCtrl.errors == null || 'passwordMismatch' in confirmPswdCtrl.errors) {
      if (fb.get('Password').value != confirmPswdCtrl.value) 
        confirmPswdCtrl.setErrors({passwordMismatch: true});
      else
        confirmPswdCtrl.setErrors(null);
    }
  }

  register(){
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };

    return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  }

  login( formData ){
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
  }

  getUserProfile(){
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')})
    return this.http.get(this.BaseURI+'/UserProfile', {headers: tokenHeader});
  }

}
