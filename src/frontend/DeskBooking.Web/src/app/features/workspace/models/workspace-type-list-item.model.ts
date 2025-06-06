import { CapacityQuantityGroup } from "./capacity-quantity-group.model";

export interface WorkspaceTypeListItem {
  id: number;
  name: string;
  description?: string;
  photoFilePaths: string[];
  amenityFilePaths: string[];
  capacities: CapacityQuantityGroup[];
}