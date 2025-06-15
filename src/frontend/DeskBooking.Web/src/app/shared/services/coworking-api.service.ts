import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { CoworkingListItem } from '../../features/coworking/models/coworking-list-item.model';
import { WorkspaceTypeListItem } from '../../features/workspace/models/workspace-type-list-item.model';
import { Workspace } from '../models/workspace.model';

@Injectable({
  providedIn: 'root'
})
export class CoworkingApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/v1/coworkings`;

  constructor(private http: HttpClient) { }

  getCoworkingList(): Observable<CoworkingListItem[]> {
    return this.http.get<CoworkingListItem[]>(this.baseUrl);
  }

  getWorkspaceTypeList(coworkingId: number): Observable<WorkspaceTypeListItem[]> {
    return this.http.get<WorkspaceTypeListItem[]>(`${this.baseUrl}/${coworkingId}/workspace-types`);
  }

  getWorkspaces(coworkingId: number, workspaceTypeId: number): Observable<Workspace[]> {
    return this.http.get<Workspace[]>(`${this.baseUrl}/${coworkingId}/workspace-types/${workspaceTypeId}/workspaces`);
  }
}