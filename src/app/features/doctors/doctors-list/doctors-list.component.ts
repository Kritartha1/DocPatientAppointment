import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../models/doctor.model';
import { DoctorService } from '../services/doctor.service';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent implements OnInit {

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

}
