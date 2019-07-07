import React from 'react';

const Summary = props => {
    const { searchHistory, productHistory } = props;

    return (
        <div className="summary">
            {
                searchHistory && (
                    <div className="summary_search-history">
                        Add Later
                    </div>
                )
            }
            {
                productHistory && (
                    <div className="summary_product-history">
                        Add Later
                    </div>
                )
            }
        </div>
    )
}