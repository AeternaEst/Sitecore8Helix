import { Cart } from "../types/Cart";

export function mapCartToProductIds(cart: Cart): string[] | undefined {
  if (!cart) {
    return undefined;
  }

  return cart.products.map(cartProduct => cartProduct.product.id);
}
