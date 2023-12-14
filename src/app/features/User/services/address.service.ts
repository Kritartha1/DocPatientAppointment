import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Address } from '../models/address.model';
import { UpdateAddress } from '../models/update-address-model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }



  getAddressById(id: string): Observable<Address> {
    return this.http.get<Address>(`${environment.apiBaseUrl}/api/Address/${id}`)
  }

  updateAddress(id: string, updateAddress: UpdateAddress): Observable<Address> {
    return this.http.put<Address>(`${environment.apiBaseUrl}/api/Address/${id}`, updateAddress)
  }

}
