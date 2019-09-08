import * as React from "react";

interface LoaderProps {
  message: string;
}

const Loader = (props: LoaderProps) => {
  const { message } = props;
  return (
    <div className="loader">
      <span>**************** {message} ****************</span>
    </div>
  );
};

export default Loader;
