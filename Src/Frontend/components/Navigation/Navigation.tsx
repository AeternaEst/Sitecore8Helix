import * as React from "react";
import SplitContainer, {
  SplitContainerMode
} from "../SplitContainer/SplitContainer";
import { ContainerBackground } from "../../types/Backgrounds";
import { NavigationProps } from "./navigation-types";
import * as classNames from "classnames";

const Navigation = (props: NavigationProps): React.ReactElement => {
  const { menuItems } = props;
  return (
    <div className="navigation">
      <div className="navigation__about">
        <img
          className="navigation__logo"
          src="/dist/images/Sitecore Logo.svg"
        />
      </div>
      <div className="navigation__links">
        <ul className="navigation__list">
          {menuItems.map(menuItem => (
            <li key={menuItem.name} className="navigation__item">
              <a href={menuItem.link}>{menuItem.name}</a>
              <div className="submenu">
                <SplitContainer
                  left={
                    <>
                      <div className="submenu__rows">
                        {menuItem.subMenu.rows.map((row, index) => (
                          <div key={index} className="submenu__row">
                            <h3
                              className={classNames("submenu__headline", {
                                ["submenu__headline--hide"]: !row.headline
                              })}
                            >
                              {row.headline || "_"}
                            </h3>
                            <ul>
                              {row.items.map(rowItem => (
                                <li
                                  key={rowItem.name}
                                  className="submenu__item"
                                >
                                  <a
                                    className="submenu__link"
                                    href={rowItem.link}
                                  >
                                    {rowItem.name}
                                  </a>
                                </li>
                              ))}
                            </ul>
                          </div>
                        ))}
                      </div>
                      <ul className="submenu__bottom">
                        {menuItem.subMenu.bottom.map(bottomItem => (
                          <li
                            key={bottomItem.name}
                            className="submenu__bottom-item"
                          >
                            <a
                              className="submenu__bottom-item-link"
                              href={bottomItem.link}
                            >
                              {bottomItem.name}
                            </a>
                          </li>
                        ))}
                      </ul>
                    </>
                  }
                  right={
                    <div className="submenu__promotion">
                      <span className="submenu__promotion-headline">
                        {menuItem.subMenu.promotion.headline}
                      </span>
                      <img
                        className="submenu__promotion-image"
                        src={menuItem.subMenu.promotion.imageUrl}
                      />
                      <a
                        className="submenu__promotion-link"
                        href={menuItem.subMenu.promotion.link.link}
                      >
                        {menuItem.subMenu.promotion.link.name}
                      </a>
                    </div>
                  }
                  leftBackground={ContainerBackground.THEME}
                  rightBackground={ContainerBackground.LIGHT}
                  mode={SplitContainerMode.EIGTHY_TWENTY}
                />
              </div>
            </li>
          ))}
        </ul>
      </div>
      <div className="navigation__actions">Comming later</div>
    </div>
  );
};

export default Navigation;
