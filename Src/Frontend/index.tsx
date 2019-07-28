import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import ProductSearchConnected from './components/Search/ProductSearch';
import CartConnected from './components/Cart/CartContainer';
import store from './store';
import './styling/app.scss';
import './components/Cart/cart.scss';

ReactDOM.render(<Provider store={store}><CartConnected /><ProductSearchConnected/></Provider>, document.getElementById('products'));