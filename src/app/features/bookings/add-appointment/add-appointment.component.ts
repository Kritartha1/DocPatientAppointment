import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css']
})
export class AddAppointmentComponent {

  constructor(private router: Router) {

  }

  printInvoice(): void {
    window.print();
  }
  book(): void {


    // window.location.replace('/slots/SlotBooked/pay/booked');
    this.router.navigateByUrl('/slots/SlotBooked/pay/booked');

  }

}
