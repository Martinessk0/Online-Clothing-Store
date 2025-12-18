import { InteractionType } from "../../enums/interaction-type";

export interface TrackInteractionRequest {
  productId?: number;
  categoryId?: number;
  type: InteractionType;
  durationSeconds?: number;
  payload?: string;
  anonymousId?: string;
}