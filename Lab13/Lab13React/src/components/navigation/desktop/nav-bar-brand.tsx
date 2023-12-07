import React from "react";
import { NavLink } from "react-router-dom";
import { NavBarTab } from "./nav-bar-tab";

export const NavBarBrand: React.FC = () => {
  return (
    <div className="nav-bar__brand">
      <NavBarTab
        path="/"
        label="🔥 Lab13 Cross Platform 🔥"
      />
    </div>
  );
};
