import * as React from "react";
import { ContainerBackground } from "../../types/Backgrounds";

export interface ContainerProps {
  children: JSX.Element;
  background: ContainerBackground;
}

const Container = (props: ContainerProps) => {
  const { children, background } = props;
  return (
    <div className={`container container--${background}`}>
      <div className="container__content">{children}</div>
    </div>
  );
};

export default Container;
