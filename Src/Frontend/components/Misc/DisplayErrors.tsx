import * as React from 'react';

const DisplayErrors = props => {
    const { hasAvailabilityError, cartIsUpdating } = props;
    return (
        <div className="display-errors">
            {
                !cartIsUpdating && hasAvailabilityError && (
                    <p>Product not available</p>
                )
            }
        </div>
    )
}

export default DisplayErrors;