import CartApi from '../webApi/CartApi';

export const ADD_TO_CART = "ADD_TO_CART";
export const DELETE_FROM_CART = "DELETE_FROM_CART";
export const SET_CART = "SET_CART";
export const GET_CART = "GET_CART";
export const SET_CART_UPDATING = "SET_CART_UPDATING";

export const ADD_TO_CART_ACTION = (productId, callback) => {
    return {
        type: ADD_TO_CART,
        productId: productId,
        callback: callback
    }
}

export const DELETE_FROM_CART_ACTION = (productId, callback) => {
    return {
        type: DELETE_FROM_CART,
        productId: productId,
        callback: callback
    }
}

export const SET_CART_ACTION = cart => {
    return {
        type: SET_CART,
        cart: cart
    }
}

export const GET_CART_ACTION = setCartCallback => {
    return {
        type: GET_CART,
        setCartCallback: setCartCallback
    }
}

export const SET_CART_UPDATING_ACTION = isUpdating => {
    return {
        type: SET_CART_UPDATING,
        isUpdating: isUpdating
    }
}

const defaultState = {
    cart: undefined,
    isUpdating: false
}

function CartReducer(state = defaultState, action) {
    switch (action.type) {
        case ADD_TO_CART:
            const api = CartApi();
            api.addToCart(action.productId, action.callback);
            return {
                ...state
            }
        case DELETE_FROM_CART:
            const cartApi = CartApi();
            cartApi.removeFromCart(action.productId, action.callback);
            return {
                ...state
            }
        case GET_CART:
            const a = CartApi();
            a.getCart(action.setCartCallback);
            return {
                ...state
            }
        case SET_CART:
            const cart = action.cart;
            return {
                ...state,
                cart
            }
        case SET_CART_UPDATING:
            const isUpdating = action.isUpdating;
            console.log("SET_CART_UPDATING");
            console.log(isUpdating);
            return {
                ...state,
                isUpdating
            }
        default:
            return state;
    }
}

export default CartReducer;