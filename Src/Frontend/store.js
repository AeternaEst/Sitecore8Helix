import { createStore, applyMiddleware, compose } from "redux";
import RootReducer from "./reducers/RootReducer";
import createSagaMiddleware from "redux-saga";
import { CartSaga } from "./sagas/CartSaga";

const sagaMiddleware = createSagaMiddleware();

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(
  RootReducer,
  /* preloadedState, */ composeEnhancers(applyMiddleware(sagaMiddleware))
);
sagaMiddleware.run(CartSaga);

export default store;
