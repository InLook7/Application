export interface CoworkingListItem {
  id: number;
  name: string,
  description?: string,
  address: string,
  photoFilePath: string,
  availableDesks: number;
  availablePrivateRooms: number;
  availableMeetingRooms: number;
}