import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { WorkspaceType } from '../models/workspace-type.model';

@Injectable({
  providedIn: 'root'
})
export class WorkspaceTypeApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/v1/workspace-types`;

  constructor(private http: HttpClient) { }

  getWorkspaceTypes(): Observable<WorkspaceType[]> {
    return this.http.get<WorkspaceType[]>(this.baseUrl);
  }
}