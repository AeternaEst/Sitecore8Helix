import { createStore, applyMiddleware } from 'redux';
import RootReducer from './reducers/RootReducer';
import createSagaMiddleware from 'redux-saga';
import { CartSaga } from './sagas/CartSaga';

const sagaMiddleware = createSagaMiddleware()
const store = createStore(
  RootReducer,
  applyMiddleware(sagaMiddleware)
);
sagaMiddleware.run(CartSaga);

export default store;