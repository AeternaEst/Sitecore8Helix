
export function mapCartToProductIds(cart) {
    if(!cart) {
        return undefined;
    }

    return cart.products.map(cartProduct => cartProduct.product.id);
}