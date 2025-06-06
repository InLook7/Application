export interface Booking {
  id: number;
  bookedByName: string;
  bookedByEmail: string;
  workspaceId: number,
  workspaceTypeId: number,
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}