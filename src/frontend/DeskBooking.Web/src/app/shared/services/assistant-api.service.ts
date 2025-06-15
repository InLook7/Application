import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { AskBookingAssistantRequest } from '../models/ask-booking-assistant-request';
import { AskBookingAssistantResponse } from '../models/ask-booking-assistant-response';

@Injectable({
  providedIn: 'root'
})
export class AssistantApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/v1/assistant`;

  constructor(private http: HttpClient) { }

  askBookingAssistant(askBookingAssistant: AskBookingAssistantRequest): Observable<AskBookingAssistantResponse> {
    return this.http.post<AskBookingAssistantResponse>(this.baseUrl, askBookingAssistant);
  }
}