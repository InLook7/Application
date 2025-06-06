export interface BookingListItem {
  id: number;
  workspaceTypeName: string,
  workspaceCapacity: number,
  photoFilePath: string,
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}