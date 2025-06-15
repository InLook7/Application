export interface UpdateBookingRequest {
  workspaceId: number,
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}