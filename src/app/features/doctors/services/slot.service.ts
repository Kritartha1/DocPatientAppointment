import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddSlotRequest } from '../models/add-slot-request';

@Injectable({
  providedIn: 'root'
})
export class SlotService {




  constructor(private http: HttpClient) { }

  addSlot(model: AddSlotRequest): Observable<ArrayBuffer> {
    return this.http.post<ArrayBuffer>(`${environment.apiBaseUrl}/api/Slots`, model);
  }
}
