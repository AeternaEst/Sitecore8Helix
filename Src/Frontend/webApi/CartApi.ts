import { Cart } from "../types/Cart";

const baseCartUrl = `http://sitecore8helix.local/api/cart/`;

export interface ProductAvailabilityResponse {
    available: boolean;
}

export interface AddToCartResponse {
    message: string;
    success: boolean;
}

export interface RemoveFromCartResponse {
    message: string;
    success: boolean;
}

const CartApi = function () {
    var myHeaders = new Headers();
    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Accept', 'application/json');
    return {
        addToCart: function (productId: string) : Promise<AddToCartResponse> {
            return fetch(`${baseCartUrl}/add`, {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify({
                    ProductId: productId,
                    Quantity: 1
                })
            })
                .then(response => {
                    return response.json()
                }).then(result => {
                    return result;
                });
        },
        removeFromCart: function (productId: string): Promise<RemoveFromCartResponse> {
            return fetch(`${baseCartUrl}/delete`, {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify({
                    ProductId: productId
                })
            })
                .then(response => {
                    return response.json()
                }).then(result => {
                    return result;
                });
        },
        getCart: function (): Promise<Cart> {
            return fetch(`${baseCartUrl}/get`)
                .then(response => {
                    return response.json();
                })
                .then(cart => {
                    return cart;
                });
        },
        checkProductAvailability: function (productId: string): Promise<ProductAvailabilityResponse> {
            return fetch(`${baseCartUrl}/checkProductAvailability`, {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify({
                    ProductId: productId
                })
            })
                .then(response => {
                    return response.json()
                }).then(result => {
                    console.log("availability response");
                    console.log(result);
                    return result;
                });
        }
    }
};

export default CartApi;