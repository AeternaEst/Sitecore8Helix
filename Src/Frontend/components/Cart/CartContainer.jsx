import React from 'react';
import { connect } from 'react-redux';
import { SET_CART_ACTION, DELETE_FROM_CART_ACTION, GET_CART_ACTION, SET_CART_UPDATING_ACTION } from '../../reducers/CartReducer';
import Cart from './Cart';
import Loader from '../Utils/Loader';

class CartContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getCart(cart => this.props.setCart(cart));
    }

    removeProductFromCart(productId) {
        this.props.setCartUpdating(true);
        this.props.deleteProduct(productId, () => {
            this.props.getCart(cart => {
                this.props.setCart(cart);
                this.props.setCartUpdating(false);
            });
        });
    }

    render() {
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
                removeProductFromCart={(productId) => this.removeProductFromCart(productId)} />
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
        setCart: cart => {
            dispatch(SET_CART_ACTION(cart));
        },
        deleteProduct: (productId, setCartCallback) => {
            dispatch(DELETE_FROM_CART_ACTION(productId, setCartCallback));
        },
        getCart: (setCartCallback) => {
            dispatch(GET_CART_ACTION(setCartCallback));
        },
        setCartUpdating: isUpdating => {
            dispatch(SET_CART_UPDATING_ACTION(isUpdating));
        }
    }
}

const CartConnected = connect(mapStateToProps, mapDispatchToProps)(CartContainer); 

export default CartConnected;