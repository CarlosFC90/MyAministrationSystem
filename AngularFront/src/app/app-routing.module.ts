import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

import { CardsAdminComponent } from './cards-admin/cards-admin.component';
import { HomeComponent } from './home/home.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: '', redirectTo:'/user/login', pathMatch: 'full'},
  {
    path:'user', component:UserComponent,
    children:[
    { path: 'registration', component:RegistrationComponent },
    { path: 'login', component:LoginComponent }
    ]
  },
  { path:'home', component:HomeComponent, canActivate:[AuthGuard] },
  { path:'user-admin', component:UserAdminComponent, canActivate:[AuthGuard] },
  { path:'cards-admin', component:CardsAdminComponent, canActivate:[AuthGuard] }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { } 
