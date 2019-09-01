import * as React from 'react';
import Facets from './Facets';
import ProductList from '../Products/ProductList';
import { ADD_TO_CART_ACTION } from '../../reducers/CartReducer';
import { connect } from 'react-redux';
import { mapCartToProductIds } from '../../utils/CartUtils';
import DisplayErrorsContainer from '../Misc/DisplayErrorsContainer';
import { Cart } from '../../types/Cart';
import { SearchResults } from '../../types/SearchResults';
import { SelectedFacet } from '../../types/Facets';

const useSolrNet = true;
const baseSearchUrl = `http://sitecore8helix.local/api/products/search${useSolrNet ? '?useSolrNet=true' : ''}`;

interface ProductSearchProps {
    addToCart: (productId: string) => any;
    cart: Cart;
    isCartUpdating: boolean;
}

interface ProductSearchState {
    result: SearchResults;
    selectedFacets: SelectedFacet[];
}

class ProductSearch extends React.Component<ProductSearchProps, ProductSearchState> {
    constructor(props) {
        super(props);
        this.state = {
            result: {
                facetResults: [],
                hits: 0,
                results: []
            },
            selectedFacets: []
        }
        this.onFacetSelect = this.onFacetSelect.bind(this);
        this.addToCart = this.addToCart.bind(this);
    }

    componentDidMount() {
        fetch(baseSearchUrl)
            .then(response => {
                return response.json();
            })
            .then(response => {
                this.setState({
                    result: response
                })
            });
    }

    addToCart(productId) {
        this.props.addToCart(productId);
    }

    onFacetSelect(facetKey: string, facetValue: string) {
        console.log(`onFacetSelected: ${facetKey} - ${facetValue}`);
        let currentFacets = this.state.selectedFacets;
        const facetExists = currentFacets.find(target => target.facetKey === facetKey);

        if (!facetExists) {
            const newFacet = {
                facetKey: facetKey,
                facetValues: [facetValue]
            };
            currentFacets.push(newFacet);
        } else {
            const facetValueExists = facetExists.facetValues.find(target => target === facetValue);
            if (!facetValueExists) {
                facetExists.facetValues.push(facetValue);
            } else {
                if (facetExists.facetValues.length === 1) {
                    currentFacets = currentFacets.filter(facet => facet.facetKey !== facetKey);
                } else {
                    facetExists.facetValues = facetExists.facetValues.filter(target => target !== facetValue);
                }
            }
        }

        console.log(currentFacets);
        this.searchProducts(currentFacets);
    }

    searchProducts(currentlySelectedFacets: SelectedFacet[]) {
        let searchString = '';
        if (currentlySelectedFacets.length) {
            searchString = `${useSolrNet ? '&Filters=' : 'Filters'}`;
            currentlySelectedFacets.forEach((facet, index) => {
                searchString += facet.facetKey + "=";
                facet.facetValues.forEach((facetValue, index) => {
                    searchString += facetValue;
                    if (index !== facet.facetValues.length - 1) {
                        searchString += ','
                    }
                });
                if (index !== currentlySelectedFacets.length - 1) {
                    searchString += "|";
                }
            });
            console.log(searchString);
        }

        fetch(baseSearchUrl + searchString)
            .then(response => {
                return response.json();
            })
            .then(response => {
                this.setState({
                    result: response,
                    selectedFacets: currentlySelectedFacets
                })
            });
    }

    render() {
        return (<div className="product-search">
            <div className="product-search__meta">
                <Facets facets={this.state.result.facetResults} selectedFacets={this.state.selectedFacets} onFacetSelect={this.onFacetSelect} />
                <DisplayErrorsContainer />
            </div>

            <ProductList products={this.state.result.results} addedProductIds={mapCartToProductIds(this.props.cart)}
                addToCart={this.addToCart} isCartLoading={this.props.isCartUpdating} />
        </div>)
    }
}

function mapStateToProps(state) {
    return {
        cart: state.cartOverview.cart,
        isCartUpdating: state.cartOverview.isUpdating
    };
}

function mapDispatchToProps(dispatch) {
    return {
        addToCart: (productId) => {
            dispatch(ADD_TO_CART_ACTION(productId));
        }
    }
}

const ProductsSearchConnected = connect(mapStateToProps, mapDispatchToProps)(ProductSearch);

export default ProductsSearchConnected;