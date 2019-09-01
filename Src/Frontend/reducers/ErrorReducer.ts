
export const SET_AVAILABILITY_ERROR = "SET_AVAILABILITY_ERROR";

export const SET_AVAILABILITY_ERROR_ACTION = (hasError: boolean) => {
    return {
        type: SET_AVAILABILITY_ERROR,
        hasError: hasError
    }
}

export interface ErrorState {
    availabilityError: boolean;
}

const initialState: ErrorState = {
    availabilityError: false
}

function ErrorReducer(state = initialState, action): ErrorState {
    switch (action.type) {
    case SET_AVAILABILITY_ERROR:
        const hasError = action.hasError;
        return {
            ...state,
            availabilityError: hasError
        }
    default:
        return state;
    }
}

export default ErrorReducer;