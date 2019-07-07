import React from 'react';

const Cart = props => {
    const { totalPrice, numberOfProducts, cart, removeProductFromCart } = props;
 
    return (
        <div className="cart">
                    <div className="cart__products">
                        {
                            cart.products.map(cartProduct => (
                                <div onClick={() => removeProductFromCart(cartProduct.product.id)}
                                    key={cartProduct.product.id} className="cart__product">
                                    <h4>{cartProduct.product.title} - ({cartProduct.quantity})</h4>
                                </div>
                            ))
                        }
                    </div>
                    <div className="cart__info">
                        <p>Total Price {totalPrice}</p>
                        <p>Number of Products {numberOfProducts}</p>
                    </div>
                    <div className="cart__checkout">
                        <button>Procceed to Checkout</button>
                    </div>
            </div>
    )
}

export default Cart;