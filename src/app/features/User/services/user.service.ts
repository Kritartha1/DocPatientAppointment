import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Slot } from '../models/slot.model';
import { UpdateUser } from '../models/update-user-model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  // addDoctor(model: AddDoctorRequest): Observable<ArrayBuffer> {
  //   return this.http.post<ArrayBuffer>(`${environment.apiBaseUrl}/api/Auth/RegisterDoctor`, model);
  // }

  // getAllDoctors(): Observable<Doctor[]> {
  //   return this.http.get<Doctor[]>(`${environment.apiBaseUrl}/api/Doctor`)
  // }

  getUserById(id: string): Observable<User> {
    return this.http.get<User>(`${environment.apiBaseUrl}/api/Users/${id}`)
  }

  updateUser(id: string, updateUserRequest: UpdateUser): Observable<User> {
    return this.http.put<User>(`${environment.apiBaseUrl}/api/Users/${id}`, updateUserRequest)
  }



  // deleteDoctor(id: string): Observable<Doctor> {
  //   return this.http.delete<Doctor>(`${environment.apiBaseUrl}/api/Doctor/${id}`)
  // }
}
