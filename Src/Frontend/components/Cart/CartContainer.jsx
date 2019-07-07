import React from 'react';
import { connect } from 'react-redux';
import { SET_CART_ACTION, DELETE_FROM_CART_ACTION, GET_CART_ACTION, SET_CART_UPDATING_ACTION } from '../../reducers/CartReducer';
import Cart from './Cart';
import Loader from '../Misc/Loader';

class CartContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getCart();
    }

    render() {
        console.log("render CartContainer");
        console.log(this.props.isCartUpdating);
        if(!this.props.cart) {
            return <Loader message="Loading Cart" />
        }
    
        if(this.props.isCartUpdating) {
            return <Loader message="Cart Updating" />
        }

        const totalPrice = this.props.cart.products.reduce((prev, current) => current.product.price + prev, 0);
        const numberOfProducts  = this.props.cart.products.length;

        return (
            <Cart totalPrice={totalPrice} numberOfProducts={numberOfProducts}  cart={this.props.cart} 
                removeProductFromCart={(productId) => this.props.deleteProduct(productId) } />
        )
    }
}

function mapStateToProps(state) {
    return {
        isCartUpdating: state.cartOverview.isUpdating,
        cart: state.cartOverview.cart,
    }
}

function mapDispatchToProps(dispatch) {
    return {
        deleteProduct: (productId) => {
            dispatch(DELETE_FROM_CART_ACTION(productId));
        },
        getCart: () => {
            dispatch(GET_CART_ACTION());
        }
    }
}

const CartConnected = connect(mapStateToProps, mapDispatchToProps)(CartContainer); 

export default CartConnected;