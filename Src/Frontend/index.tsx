import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import ProductSearchConnected from './components/Search/ProductSearch';
import CartConnected from './components/Cart/CartContainer';
import Message from './components/Message/Message';
import messageTestData from './components/Message/message-test-data';
import store from './store';
import './main.scss';
import Container from './components/Container/Container';
import Navigation from './components/Navigation/Navigation';
import { ContainerBackground } from './types/Backgrounds';

const ProductsPage = props => {
    return (
        <div className="products-page">
            <Message {...messageTestData} />
            <Container background={ContainerBackground.DEFAULT_GREY }>
                <Navigation />
            </Container>
            <CartConnected />
            <ProductSearchConnected/>
        </div>
    )
}

ReactDOM.render(<Provider store={store}><ProductsPage /></Provider>, document.getElementById('products'));