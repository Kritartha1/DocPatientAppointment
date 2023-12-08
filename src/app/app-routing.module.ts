import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDoctorComponent } from './features/doctors/add-doctor/add-doctor.component';
import { DoctorsListComponent } from './features/doctors/doctors-list/doctors-list.component';
import { EditDoctorComponent } from './features/doctors/edit-doctor/edit-doctor.component';
import { DoctorCardListComponent } from './features/doctors/doctor-card-list/doctor-card-list.component';
import { DoctorCardComponent } from './features/doctors/doctor-card/doctor-card.component';
import { BookSlotComponent } from './features/slots/book-slot/book-slot.component';
import { LoginComponent } from './features/auth/login/login.component';
import { authGuard } from './features/auth/guard/auth.guard';



const routes: Routes = [
  {
    path: 'admin/doctors',
    component: DoctorsListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin/add-doctor',
    component: AddDoctorComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/doctors/:id',
    component: EditDoctorComponent,
    canActivate: [authGuard]
  },
  {
    path: 'doctors',
    component: DoctorCardListComponent
  },
  // {
  //   path: 'doctors',
  //   component: DoctorCardComponent
  // }
  {
    path: 'slots/:id',
    component: DoctorCardComponent
  }, {
    path: 'slots/SlotBooked',
    component: BookSlotComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
