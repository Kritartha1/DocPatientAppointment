
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../models/doctor.model';
import { DoctorService } from '../services/doctor.service';

@Component({
  selector: 'app-doctor-card-list',
  templateUrl: './doctor-card-list.component.html',
  styleUrls: ['./doctor-card-list.component.css']
})
export class DoctorCardListComponent implements OnInit {

  // doctors?: Doctor[];
  doctors$?: Observable<Doctor[]>;

  constructor(private doctorService: DoctorService) {

  }
  ngOnInit(): void {
    this.doctors$ = this.doctorService.getAllDoctors();


    // .subscribe({
    //   next:(response)=>{
    //     this.doctors=response;
    //   }
    // })
  }
  // onCardClick(doctorId: string): void {
  //   // Store the selected doctor ID in the service
  //   // this.doctorService.setSelectedDoctorId(doctorId);
  // }

}
