import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../auth/services/auth.service';
import { Address } from '../models/address.model';
import { UpdateAddress } from '../models/update-address-model';
import { UpdateUser } from '../models/update-user-model';
import { User } from '../models/user.model';
import { AddressService } from '../services/address.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit, OnDestroy {

  public dob?: string; // Assuming the date is a string; adjust as needed
  public age?: number;
  public maxDate?: string; // To store the max date

  user?: User;
  address?: Address
  editUserSubscription?: Subscription;
  editAddressSubscription?: Subscription;
  id: string | null;
  ad_id: string | null;


  constructor(private userService: UserService,
    private authService: AuthService,
    private router: Router,
    private addressService: AddressService) {
    this.id = "";
    this.ad_id = "";
    // this.address = {
    //   id: "",
    //   locality: "",
    //   city: "",
    //   state: ""
    // };


  }

  ngOnInit(): void {
    this.maxDate = this.getCurrentDate();
    this.id = localStorage.getItem('user-Id');
    if (this.id) {
      console.log(this.id);
      this.editUserSubscription = this.userService.getUserById(this.id)
        .subscribe(
          {
            next: (response) => {
              this.user = response;

              this.ad_id = this.user.addressId;
              this.editAddressSubscription = this.addressService.getAddressById(this.ad_id)
                .subscribe(
                  {
                    next: (res) => {
                      this.address = res;

                    }
                  }
                )


            }
          }
        )
    }
  }

  OnFormSubmit(): void {
    const updateUserRequest: UpdateUser = {

      name: this.user?.name ?? '',
      age: this.user?.age ?? 0,
      dob: this.user?.dob ?? "2023-12-12T12:19:53.929Z",
    };
    const updateAddressRequest: UpdateAddress = {

      locality: this.address?.locality ?? '',
      city: this.address?.city ?? '',
      state: this.address?.state ?? ''
    };

    if (this.id && this.ad_id) {
      const ad = this.ad_id;
      this.editUserSubscription = this.userService.updateUser(this.id, updateUserRequest)
        .subscribe({
          next: (response) => {
            this.editAddressSubscription = this.addressService.updateAddress(ad, updateAddressRequest)
              .subscribe({
                next: (res) => {
                  console.log(res);

                }
              });
            console.log(response);

          }
        });


    }
  }

  calculateAge(): void {
    if (this.dob) {
      const today = new Date();
      const birthDate = new Date(this.dob);
      console.log(birthDate, today);

      let age = today.getFullYear() - birthDate.getFullYear();

      const monthDiff = today.getMonth() - birthDate.getMonth();

      if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }

      console.log("age:", age);

      this.age = age;
    }

  }

  getCurrentDate(): string {
    const today = new Date();
    const year = today.getFullYear();
    const month = (today.getMonth() + 1).toString().padStart(2, '0');
    const day = today.getDate().toString().padStart(2, '0');

    return `${year}-${month}-${day}`;
  }

  ngOnDestroy(): void {
    this.editAddressSubscription?.unsubscribe();
    this.editUserSubscription?.unsubscribe();
  }




}









