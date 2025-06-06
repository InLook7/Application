import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';
import { Booking } from '../../../shared/models/booking.model';
import { CreateBookingRequest } from '../models/create-booking-request';
import { BookingListItem } from '../models/booking-list-item.model';

@Injectable({
  providedIn: 'root'
})
export class BookingApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/v1/bookings`;

  constructor(private http: HttpClient) { }

  getBookingList(): Observable<BookingListItem[]> {
    return this.http.get<BookingListItem[]>(this.baseUrl);
  }

  getBookingById(id: number): Observable<Booking> {
    return this.http.get<Booking>(`${this.baseUrl}/${id}`);
  }

  createBooking(createBookingRequest: CreateBookingRequest) {
    return this.http.post<Booking>(this.baseUrl, createBookingRequest);
  }

  patchBooking(id: number, partialBooking: Partial<Booking>): Observable<Booking> {
    return this.http.patch<Booking>(`${this.baseUrl}/${id}`, partialBooking);
  }

  deleteBooking(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
