export interface CreateBookingRequest {
  bookedByName: string;
  bookedByEmail: string;
  workspaceId: number,
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}