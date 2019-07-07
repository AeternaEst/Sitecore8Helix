
const baseCartUrl = `http://sitecore8helix.local/api/cart/`;

const CartApi = function() {
    var myHeaders = new Headers();
    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Accept', 'application/json');
    return {
        addToCart: function(productId, callback) {
            fetch(`${baseCartUrl}/add`, {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify({
                    ProductId: productId,
                    Quantity: 1
                })
            })
                .then(response => {
                    return response.json()
                }).then(result => {
                    callback();
                });
        },
        removeFromCart: function(productId, callback) {
            fetch(`${baseCartUrl}/delete`, {
                method: "POST",
                headers: myHeaders,
                body: JSON.stringify({
                    ProductId: productId
                })
            })
                .then(response => {
                    return response.json()
                }).then(result => {
                    callback();
                });
        },
        getCart: function(callback) {
            fetch(`${baseCartUrl}/get`)
                .then(response => {
                    return response.json();
                })
                .then(cart => {
                    callback(cart)
                });
        }
    }   
};

export default CartApi;