import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'dateRangeDuration'
})
export class DateRangeDurationPipe implements PipeTransform {
  transform(startDate: string, endDate: string): string {
    const start = new Date(startDate);
      const end = new Date(endDate);

    const diffInMs = end.getTime() - start.getTime();
    const days = Math.floor(diffInMs / (1000 * 60 * 60 * 24)) + 1;

    return `${days} ${days === 1 ? 'day' : 'days'}`;
  }
}