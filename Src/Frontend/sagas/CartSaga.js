import "regenerator-runtime/runtime";
import { put, call, takeLatest } from 'redux-saga/effects';
import { SET_CART_ACTION, SET_CART_UPDATING_ACTION, GET_CART, DELETE_FROM_CART } from '../reducers/CartReducer';
import CartApi from '../webApi/CartApi';

function* getCart() {
    const cart = yield call(() => CartApi().getCart());
    yield put(SET_CART_ACTION(cart));
}

function* removeFromCart(action) {
    yield put(SET_CART_UPDATING_ACTION(true));
    yield call(() => CartApi().removeFromCart(action.productId));
    yield getCart();
    yield put(SET_CART_UPDATING_ACTION(false));
}

export function* CartSaga() {
  yield takeLatest(GET_CART, getCart);
  yield takeLatest(DELETE_FROM_CART, removeFromCart);
}