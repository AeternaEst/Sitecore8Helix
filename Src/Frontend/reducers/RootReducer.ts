import { combineReducers  } from 'redux';
import CartReducer, { CartOverviewState } from './CartReducer';
import ErrorReducer, { ErrorState } from './ErrorReducer';

export interface RootState {
    cartOverview: CartOverviewState | undefined;
    errors: ErrorState | undefined;
}

const initialState: RootState = {
    cartOverview: undefined,
    errors: undefined
}

function RootReducer(state = initialState, action) {
    return {
        cartOverview: CartReducer(state.cartOverview, action),
        errors: ErrorReducer(state.errors, action) 
    }
}

const combinedReducers = combineReducers({
    cartOverview: CartReducer
});

export default RootReducer;