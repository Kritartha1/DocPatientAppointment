import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';
import { fromEvent, Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-booked-appointment',
  templateUrl: './booked-appointment.component.html',
  styleUrls: ['./booked-appointment.component.css']
})
export class BookedAppointmentComponent {
  private unsubscriber: Subject<void> = new Subject<void>();
  constructor(private authService: AuthService, private router: Router) {

  }

  ngOnInit(): void {
    history.pushState(null, '');

    fromEvent(window, 'popstate').pipe(
      takeUntil(this.unsubscriber)
    ).subscribe((_) => {
      // history.pushState(null, '');
      // alert(`Can't resubmit form`);
      const currentUrl = this.router.url;

      // Check if the current URL is the one for which you want to disable the back button
      if (currentUrl === '/slots/SlotBooked/pay/booked') {
        // Prevent going back and display a message
        history.pushState(null, '');
        alert(`Can't resubmit form for this specific URL`);
      }
    });
  }

  printInvoice(): void {
    window.print();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigateByUrl('/login');
  }

}
