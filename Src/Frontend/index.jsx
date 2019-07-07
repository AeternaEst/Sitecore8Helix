import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import ProductSearchConnected from './components/Search/ProductSearch';
import CartConnected from './components/Cart/CartContainer';
import store from './store';

ReactDOM.render(<Provider store={store}><CartConnected /><ProductSearchConnected/></Provider>, document.getElementById('products'));