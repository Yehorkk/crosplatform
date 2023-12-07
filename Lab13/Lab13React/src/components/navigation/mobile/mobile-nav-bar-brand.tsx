import React from "react";
import { NavLink } from "react-router-dom";
import { NavBarTab } from "../desktop/nav-bar-tab";

interface MobileNavBarBrandProps {
  handleClick: () => void;
}

export const MobileNavBarBrand: React.FC<MobileNavBarBrandProps> = ({ handleClick }) => {
  return (
    <div
      onClick={handleClick}
      className="mobile-nav-bar__brand"
    >
      <NavBarTab
        path="/"
        label="🔥 Lab13 Cross Platform 🔥"
      />
    </div>
  );
};
