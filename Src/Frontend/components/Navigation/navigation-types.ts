export interface NavigationProps {
    menuItems: MenuItem[];
}

interface MenuItem {
    name: string;
    link: string;
    subMenu: SubMenu;
}

interface SubMenu {
    rows: SubMenuRow[];
    bottom: SubMenuItem[];
    promotion: SubMenuPromotion;
}

interface SubMenuRow {
    headline?: string;
    items: SubMenuItem[];
}

interface SubMenuItem {
    name: string;
    link: string;
}

interface SubMenuPromotion {
    headline: string;
    imageUrl: string;
    link: SubMenuItem;
}