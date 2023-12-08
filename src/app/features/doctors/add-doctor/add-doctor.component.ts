import { Component, OnDestroy } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AddDoctorRequest } from '../models/add-doctor-request';
import { DoctorService } from '../services/doctor.service';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrls: ['./add-doctor.component.css']
})
export class AddDoctorComponent implements OnDestroy {

  model: AddDoctorRequest;
  private addDoctorSubscription?: Subscription;

  constructor(private doctorService: DoctorService,
    private router: Router) {
    this.model = {
      username: 'doctor@gmail.com',
      password: 'Password@123',
      name: '',
      qualifications: '',
      specialization: '',
      hospital: '',
      roles: ['doctor']
    }
  }

  onFormSubmit() {
    this.addDoctorSubscription = this.doctorService.addDoctor(this.model)
      .subscribe(
        {
          next: (response) => {
            this.router.navigateByUrl('/admin/doctors');
            console.log("This was succesfull");
          },
        }
      )
  }

  ngOnDestroy(): void {
    this.addDoctorSubscription?.unsubscribe();
  }

}
