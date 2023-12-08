import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { AddDoctorRequest } from '../models/add-doctor-request';
import { Doctor } from '../models/doctor.model';
import { UpdateDoctorRequest } from '../models/update-doctor-request';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http: HttpClient) { }

  addDoctor(model: AddDoctorRequest): Observable<ArrayBuffer> {
    return this.http.post<ArrayBuffer>(`${environment.apiBaseUrl}/api/Auth/RegisterDoctor`, model);
  }

  getAllDoctors(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(`${environment.apiBaseUrl}/api/Doctor`)
  }

  getDoctorById(id: string): Observable<Doctor> {
    return this.http.get<Doctor>(`${environment.apiBaseUrl}/api/Doctor/${id}`)
  }

  updateDoctor(id: string, updateDoctorRequest: UpdateDoctorRequest): Observable<Doctor> {
    return this.http.put<Doctor>(`${environment.apiBaseUrl}/api/Doctor/${id}`, updateDoctorRequest)
  }

  deleteDoctor(id: string): Observable<Doctor> {
    return this.http.delete<Doctor>(`${environment.apiBaseUrl}/api/Doctor/${id}`)
  }


}

