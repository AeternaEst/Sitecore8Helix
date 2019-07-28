import * as React from 'react';

interface DisplayErrorsProps {
    hasAvailabilityError: boolean;
    cartIsUpdating: boolean;
}

const DisplayErrors = (props: DisplayErrorsProps) => {
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