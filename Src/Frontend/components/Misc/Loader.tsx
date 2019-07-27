import * as React from 'react';

const Loader = props => {
    const { message } = props;
    return (
        <div className="loader">
            <span>**************** {message} ****************</span>
        </div>
    )
}

export default Loader;