import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { DoctorsListComponent } from './features/doctors/doctors-list/doctors-list.component';
import { AddDoctorComponent } from './features/doctors/add-doctor/add-doctor.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditDoctorComponent } from './features/doctors/edit-doctor/edit-doctor.component';
import { DoctorCardListComponent } from './features/doctors/doctor-card-list/doctor-card-list.component';
import { DoctorCardComponent } from './features/doctors/doctor-card/doctor-card.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { BookSlotComponent } from './features/slots/book-slot/book-slot.component';
import { LoginComponent } from './features/auth/login/login.component';
import { AddAppointmentComponent } from './features/bookings/add-appointment/add-appointment.component';
import { BookedAppointmentComponent } from './features/bookings/booked-appointment/booked-appointment.component';
import { HomePageComponent } from './core/components/home-page/home-page.component';

import { UserProfileComponent } from './features/User/user-profile/user-profile.component';
import { UpdateUserComponent } from './features/User/update-user/update-user.component';
import { UpdateAddressComponent } from './features/User/update-address/update-address.component';
import { UserAppointmentsComponent } from './features/User/user-appointments/user-appointments.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DoctorsListComponent,
    AddDoctorComponent,
    EditDoctorComponent,
    DoctorCardListComponent,
    DoctorCardComponent,
    BookSlotComponent,
    LoginComponent,
    AddAppointmentComponent,
    BookedAppointmentComponent,
    HomePageComponent,

    UserProfileComponent,
     UpdateUserComponent,
     UpdateAddressComponent,
     UserAppointmentsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatNativeDateModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
