import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';

const routes: Routes = [
  {path:'',redirectTo:'/User/SignUp',pathMatch:'full'},
  {
    path: 'User', component: UserComponent,
    children: [
      { path: 'SignUp', component: RegistrationComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
