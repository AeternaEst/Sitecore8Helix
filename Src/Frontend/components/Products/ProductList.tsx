import * as React from 'react';
import Product from './Product';
import Loader from '../Misc/Loader';

const ProductList = props => {
    const { products, addedProductIds, addToCart, isCartLoading } = props;

    if(!products)
        return <Loader message="No Products" />;

    return (
        <div className="product-list">
            {
                products.map(product => (
                    <Product key={product.id} product={product} addedProductIds={addedProductIds} addToCart={addToCart} isCartLoading={isCartLoading}/>
                ))
            }
        </div>
    )
}

export default ProductList;