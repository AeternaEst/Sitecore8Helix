import React, { useState } from 'react';
import classNames from 'classnames';
import Loader from '../Utils/Loader';

const Product = props => {
    const { product, addedProductIds, addToCart, isCartLoading } = props;

    const [isLoading, setIsLoading] = useState(false);

    if(isLoading && !isCartLoading) {
        setIsLoading(false);
    }

    return (
        <div className={classNames("product-list__product",
            { "product-list__product--selected":addedProductIds && addedProductIds.find(addedProduct => addedProduct === product.id) })}>

            {
                isLoading && isCartLoading ? (
                    <Loader message="Product Loading" />
                ) : (
                    <>
                    <ul >
                        <li>{product.title}</li>
                        <li>{product.description}</li>
                        <li>{product.price}</li>
                        <li>{product.category}</li>
                        <li>{product.rating}</li>
                        <li>{product.type}</li>
                        <li>{product.introDate}</li>
                    </ul>
                    <button onClick={() => { setIsLoading(true); addToCart(product.id)}}>Add To Cart</button>
                    </>
                )
            }
        </div>
    )
}

export default Product;