import * as React from 'react';
import Product, { ProductPropsBase } from './Product';
import Loader from '../Misc/Loader';
import { Product as ProductType } from '../../types/Product';

interface ProductListProps extends ProductPropsBase {
    products: ProductType[];
}

const ProductList = (props: ProductListProps) => {
    const { products, addedProductIds, addToCart, isCartLoading } = props;

    if (!products)
        return <Loader message="No Products" />;

    return (
        <div className="product-list">
            {
                products.map(product => (
                    <Product key={product.id} product={product} addedProductIds={addedProductIds} addToCart={addToCart} isCartLoading={isCartLoading} />
                ))
            }
        </div>
    )
}

export default ProductList;