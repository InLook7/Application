export interface Booking {
  id: number;
  bookedByName: string;
  bookedByEmail: string;
  coworkingId: number,
  workspaceId: number,
  workspaceTypeId: number,
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}