import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Doctor } from '../models/doctor.model';
import { DoctorService } from '../services/doctor.service';
import { ChangeDetectorRef } from '@angular/core';
import { AddSlotRequest } from '../models/add-slot-request';
import { SlotService } from '../services/slot.service';
import { AuthService } from '../../auth/services/auth.service';
// import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrls: ['./doctor-card.component.css']
})
export class DoctorCardComponent implements OnInit {

  id: string | null = null;
  paramsSubscription?: Subscription;
  slotSubscription?: Subscription;
  doctor?: Doctor;
  clickedIndex: number | null = null;
  minDate: string | null = null;
  selectedDate: string | null = null;
  selectedTime: string | null = null;

  model: AddSlotRequest;
  private addSlotSubscription?: Subscription;


  constructor(private authService: AuthService, private route: ActivatedRoute,
    private doctorService: DoctorService,
    private router: Router, private cdRef: ChangeDetectorRef, private slotService: SlotService) {
    this.model = {
      startTime: '',
      endTime: '',
      userId: '',
      doctorId: ''


    }

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
                    this.setMinDate();
                  }
                }
              )
          }
        }


      }
    );
  }

  timeButtons = [
    { label: '4:00-5:00 pm', time: '16:00:00' },
    { label: '5:00-6:00 pm', time: '17:00:00' },
    { label: '6:00-7:00 pm', time: '18:00:00' },
    { label: '7:00-8:00 pm', time: '19:00:00' },
    { label: '8:00-9:00 pm', time: '20:00:00' },
    { label: '9:00-10:00 pm', time: '21:00:00' },
  ];

  setMinDate() {
    const today = new Date();
    const year = today.getFullYear();
    const month = ('0' + (today.getMonth() + 1)).slice(-2);
    const day = ('0' + today.getDate()).slice(-2);

    this.minDate = `${year}-${month}-${day}`;
  }

  DateSelected: any;

  fetchSelectedDate() {
    console.log(this.DateSelected);
  }

  // public isButtonClicked: boolean[] = [false, false, false, false, false, false];

  isButtonClicked(index: number): boolean {
    return this.clickedIndex === index;
  }

  toggleButtonColor(index: number): void {
    if (this.clickedIndex === index) {
      // If the same button is clicked again, revert to its original state
      this.clickedIndex = null;
    } else {
      // If a different button is clicked, highlight it and revert the previously clicked button
      this.clickedIndex = index;
    }
  }

  createDateTimeString(): void {
    // Validate that both date and time are selected before creating the DateTime string
    if (!this.selectedDate || !this.selectedTime) {


      alert('Please select both date and time.');
      return;
      // return '';
    }

    // Concatenate date and time strings to form the DateTime string
    const dateTimeString = `${this.selectedDate}T${this.selectedTime}.000`;
    const user_ = this.authService.getuser()

    if (this.id && user_ && user_.id) {
      this.model.startTime = dateTimeString;
      this.model.endTime = dateTimeString;
      this.model.doctorId = this.id;
      this.model.userId = user_.id;

      console.log(this.model);


      // return dateTimeString;
      this.addSlotSubscription = this.slotService.addSlot(this.model)
        .subscribe(
          {
            next: (response) => {
              console.log(this.router);
              // this.router.navigateByUrl('/');
              this.router.navigateByUrl('/slots/SlotBooked/pay');
              alert("Slot booking was successful!");

            },
            error(err) {
              alert("Please choose a new slot");

            },
          }
        )
      //this.model.userId=fromToken
    } else {
      alert("Please login!");
      this.router.navigateByUrl('/login');
    }





    //make a slot booking.
    //if slot booking possible,greet slot booked else say please select a new slot
    // return dateTimeString;
  }

  handleButtonClick(time: string): void {
    this.selectedTime = time;
    this.detectChanges();
  }
  private detectChanges(): void {
    try {
      this.cdRef.detectChanges();
    } catch (e) {
      // Handle the exception (if any)
      console.error(e);
    }
  }



  ngOnDestroy(): void {
    this.addSlotSubscription?.unsubscribe();

  }

}
