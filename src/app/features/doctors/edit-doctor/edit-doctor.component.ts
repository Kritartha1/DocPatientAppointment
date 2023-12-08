import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { __param } from 'tslib';
import { Doctor } from '../models/doctor.model';
import { UpdateDoctorRequest } from '../models/update-doctor-request';
import { DoctorService } from '../services/doctor.service';

@Component({
  selector: 'app-edit-doctor',
  templateUrl: './edit-doctor.component.html',
  styleUrls: ['./edit-doctor.component.css']
})
export class EditDoctorComponent implements OnInit, OnDestroy {


  id: string | null = null;
  paramsSubscription?: Subscription;
  editDoctorSubscription?: Subscription;
  doctor?: Doctor;



  constructor(private route: ActivatedRoute,
    private doctorService: DoctorService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe(
      {
        next: (params) => {
          this.id = params.get('id');
          if (this.id) {
            this.doctorService.getDoctorById(this.id)
              .subscribe(
                {
                  next: (response) => {
                    this.doctor = response;
                  }
                }
              )
          }
        }
      }
    );
  }

  OnFormSubmit(): void {
    const updateDoctorRequest: UpdateDoctorRequest = {
      userName: this.doctor?.userName ?? '',
      email: this.doctor?.email ?? '',
      name: this.doctor?.name ?? '',
      qualifications: this.doctor?.qualifications ?? '',
      specialization: this.doctor?.specialization ?? '',
      hospital: this.doctor?.hospital ?? '',
      fees: this.doctor?.fees ?? 500
    };
    if (this.id) {
      this.editDoctorSubscription = this.doctorService.updateDoctor(this.id, updateDoctorRequest)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/doctors');
          }
        });
    }
  }

  onDelete(): void {
    if (this.id) {
      this.editDoctorSubscription = this.doctorService.deleteDoctor(this.id)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/doctors');
          }
        });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editDoctorSubscription?.unsubscribe();
  }


}
