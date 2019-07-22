import { combineReducers  } from 'redux';
import ProductsReducer from './ProductsReducer';
import CartReducer from './CartReducer';

function RootReducer(state = {}, action) {
    return {
        products: ProductsReducer(state.products, action),
        cartOverview: CartReducer(state.cartOverview, action)
    }
}

const combinedReducers = combineReducers({
    products: ProductsReducer,
    cartOverview: CartReducer
});

export default RootReducer;