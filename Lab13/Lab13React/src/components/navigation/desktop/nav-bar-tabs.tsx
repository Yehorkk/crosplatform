import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { NavBarTab } from "./nav-bar-tab";

export const NavBarTabs: React.FC = () => {
  const { isAuthenticated } = useAuth0();

  return (
    <div className="nav-bar__tabs">
      <NavBarTab
        path="/profile"
        label={isAuthenticated ? "Профіль" : "Профіль (ви не авторизовані)"}
      />
      <NavBarTab
        path="/public"
        label="Публічна інформація"
      />
      {isAuthenticated && (
        <>
          <NavBarTab
            path="/protected"
            label="Захищена інформація"
          />
        </>
      )}
    </div>
  );
};
