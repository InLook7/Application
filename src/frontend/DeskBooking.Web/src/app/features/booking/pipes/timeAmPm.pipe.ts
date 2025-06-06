import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeAmPm'
})
export class TimeAmPmPipe implements PipeTransform {
  transform(value: string): string {
    const [hourStr, minute] = value.split(':');

    let hour = parseInt(hourStr, 10);
    const ampm = hour >= 12 ? 'PM' : 'AM';
    hour = hour % 12;
    if (hour === 0) hour = 12;

    return `${hour}:${minute} ${ampm}`;
  }
}