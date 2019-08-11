import * as React from 'react';
import SplitContainer, { SplitContainerMode } from '../SplitContainer/SplitContainer';
import { ContainerBackground } from '../../types/Backgrounds';

const Navigation = (props) => {

    return (
        <div className="navigation">
            <div className="navigation__about">
                <img className="navigation__logo" src="/dist/images/Sitecore Logo.svg" />
            </div> 
            <div className="navigation__links">
                <ul className="navigation__list">
                    <li className="navigation__item">
                        <a href="#">DAME</a>
                        <div className="submenu">
                            <SplitContainer
                                left={(
                                    <div className="submenu__rows">
                                        <div className="submenu__row">
                                            <h3 className="submenu__headline">Sko</h3>
                                            <ul>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Sneakers</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Slip-ons</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Sandaler</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Outdoor</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Højhælede</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Golf</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div className="submenu__row">
                                            <h3 className="submenu__headline submenu__headline--hide">No Header</h3>
                                            <ul>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Flade Sko</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Støvler</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Goretex</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div className="submenu__row">
                                            <h3 className="submenu__headline">Skotilbehør</h3>
                                            <ul>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Strømper</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Indlægssåler</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Snørrebånd</a>
                                                </li>
                                                <li className="submenu__item">
                                                    <a className="submenu__link" href="#">Plejeprodukter</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                )}
                                right={(
                                    <div className="submenu__promotion">
                                        Comming Later
                                    </div>
                                )}
                                leftBackground={ContainerBackground.THEME}
                                rightBackground={ContainerBackground.LIGHT}
                                mode={SplitContainerMode.EIGTHY_TWENTY} />
                        </div>
                    </li>
                    <li className="navigation__item">
                        <a href="#">HERRE</a>
                        <div className="submenu">
                            <div className="submenu__row">
                                <h3 className="submenu__headline">ARNOLD</h3>
                                <ul>
                                    <li className="submenu__item">
                                        <a className="submenu__link" href="#">STALLONE</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </li>
                    <li className="navigation__item"><a href="#">BØRN</a></li>
                    <li className="navigation__item"><a href="#">OUTDOOR</a></li>
                    <li className="navigation__item"><a href="#">GOLF</a></li>
                    <li className="navigation__item"><a href="#">TASKER</a></li>
                    <li className="navigation__item"><a href="#">ACCESSORIES</a></li>
                </ul>
            </div>
            <div className="navigation__actions">
                Comming later   
            </div>
        </div>
    )
}

export default Navigation;