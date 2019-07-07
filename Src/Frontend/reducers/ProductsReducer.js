
const ADDING_PRODUCT = "ADDING_PRODUCT";
const FINISHED_ADDING_PRODUCT = "FINISHED_ADDING_PRODUCT";
const DELETING_PRODUCT = "DELETING_PRODUCT";
const FINISHED_DELETING_PRODUCT = "FINISHED_DELETING_PRODUCT";

export const ADDING_PRODUCT_ACTION = {
    type: ADDING_PRODUCT
};
export const FINISHED_ADDING_PRODUCT_ACTION = {
    type: FINISHED_ADDING_PRODUCT
};

export const DELETING_PRODUCT_ACTION = {
    type: DELETING_PRODUCT
};
export const FINISHED_DELETING_PRODUCT_ACTION = {
    type: FINISHED_DELETING_PRODUCT
};

const defaultState = {
    addingProduct: false,
    deletingProduct: false
}

function ProductsReducer(state = defaultState, action) {
    switch (action.type) {
        case ADDING_PRODUCT:
            return {
                ...state,
                addingProduct: true
            }
        case FINISHED_ADDING_PRODUCT:
            return {
                ...state,
                addingProduct: false
            }
        case DELETING_PRODUCT:
            return {
                ...state,
                deletingProduct: true
            }
        case FINISHED_DELETING_PRODUCT:
            return {
                ...state,
                deletingProduct: false
            }
        default:
            return state;
    }
}

export default ProductsReducer;