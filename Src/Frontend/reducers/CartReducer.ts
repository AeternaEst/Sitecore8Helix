import { Cart } from "../types/Cart";

export const ADD_TO_CART = "ADD_TO_CART";
export const DELETE_FROM_CART = "DELETE_FROM_CART";
export const SET_CART = "SET_CART";
export const GET_CART = "GET_CART";
export const SET_CART_UPDATING = "SET_CART_UPDATING";

export const ADD_TO_CART_ACTION = (productId: string) => {
    return {
        type: ADD_TO_CART,
        productId: productId
    }
}

export const DELETE_FROM_CART_ACTION = (productId: string) => {
    return {
        type: DELETE_FROM_CART,
        productId: productId
    }
}

export const SET_CART_ACTION = (cart: Cart) => {
    return {
        type: SET_CART,
        cart: cart
    }
}

export const GET_CART_ACTION = () => {
    return {
        type: GET_CART
    }
}

export const SET_CART_UPDATING_ACTION = (isUpdating: boolean) => {
    return {
        type: SET_CART_UPDATING,
        isUpdating: isUpdating
    }
}

export interface CartOverviewState {
    cart: Cart | undefined;
    isUpdating: boolean;
}

const defaultState: CartOverviewState = {
    cart: undefined,
    isUpdating: false
} 

function CartReducer(state = defaultState, action): CartOverviewState {
    switch (action.type) {
        case SET_CART:
            const cart = action.cart;
            return {
                ...state,
                cart
            }
        case SET_CART_UPDATING:
            const isUpdating = action.isUpdating;
            return {
                ...state,
                isUpdating
            }
        default:
            return state;
    }
}

export default CartReducer;