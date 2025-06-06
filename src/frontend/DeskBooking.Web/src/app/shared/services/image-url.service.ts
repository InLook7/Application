import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageUrlService {
  getImageUrl(imagePath: string): string {
    return `${environment.apiUrl}/${imagePath}`;
  }
}