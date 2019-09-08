import { CartProduct } from "./CartProduct";

export interface Cart {
  cartId: string;
  products: CartProduct[];
}
