import * as React from 'react';
import { ContainerBackground } from '../../types/Backgrounds';

export interface SplitContainerProps {
    left: JSX.Element;
    right: JSX.Element;
    leftBackground: ContainerBackground;
    rightBackground: ContainerBackground;
    mode: SplitContainerMode;
}

export enum SplitContainerMode {
    FIFTY_FIFTY = "fifty-fifty",
    EIGTHY_TWENTY = "eigthy-twenty"
}

const SplitContainer = (props: SplitContainerProps) => {
    const { left, right, leftBackground, rightBackground } = props;
    return (
        <div className={`split-container`}>
            <div className={`split-container__edge split-container__edge--${leftBackground}`}></div>
            <div className={`split-container__left-content split-container__left-content--${props.mode} split-container__content--${leftBackground}`}>
                {left}
            </div>
            <div className={`split-container__right-content split-container__right-content--${props.mode} split-container__content--${rightBackground}`}>
                {right}
            </div>
            <div className={`split-container__edge split-container__edge--${rightBackground}`}></div>
        </div>
    )
}

export default SplitContainer;