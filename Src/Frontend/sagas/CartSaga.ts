import "regenerator-runtime/runtime";
import { put, call, takeLatest, takeEvery } from 'redux-saga/effects';
import { SET_CART_ACTION, SET_CART_UPDATING_ACTION, GET_CART, DELETE_FROM_CART, ADD_TO_CART } from '../reducers/CartReducer';
import { SET_AVAILABILITY_ERROR_ACTION } from '../reducers/ErrorReducer';
import CartApi, { ProductAvailabilityResponse } from '../webApi/CartApi';
import { Cart } from "../types/Cart";

function* getCart() {
    const cart: Cart = yield call(() => CartApi().getCart());
    yield put(SET_CART_ACTION(cart));
}

function* checkProductAvailability(productId: string) {
    const response: ProductAvailabilityResponse = yield call(() => CartApi().checkProductAvailability(productId));
    return response.available;
}

function* removeFromCart(action) {
    yield put(SET_CART_UPDATING_ACTION(true));
    yield call(() => CartApi().removeFromCart(action.productId));
    yield getCart();
    yield put(SET_CART_UPDATING_ACTION(false));
}

function* addToCart(action) {
    yield put(SET_CART_UPDATING_ACTION(true));
    var isAvailable = yield checkProductAvailability(action.productId);
    if (!isAvailable) {
        yield put(SET_AVAILABILITY_ERROR_ACTION(true));
    } else {
        yield put(SET_AVAILABILITY_ERROR_ACTION(false));
        yield call(() => CartApi().addToCart(action.productId));
        yield getCart();
    }
    yield put(SET_CART_UPDATING_ACTION(false));
}

export function* CartSaga() {
    yield takeLatest(GET_CART, getCart);
    yield takeEvery(DELETE_FROM_CART, removeFromCart);
    yield takeEvery(ADD_TO_CART, addToCart);
}