import React from "react";
import { HeroBanner } from "src/components/hero-banner";
import { PageLayout } from "../components/page-layout";
import { useAuth0 } from "@auth0/auth0-react";
import { NavLink } from "react-router-dom";

export const HomePage: React.FC = () => {
  const { isAuthenticated, loginWithRedirect } = useAuth0();

  const handleLogin = async () => {
    await loginWithRedirect({
      appState: {
        returnTo: "/profile",
      },
      authorizationParams: {
        prompt: "login",
      },
    });
  };

  return (
    <PageLayout>
      <>
        <HeroBanner />
        <div>
          <h2 style={{ color: "white", textAlign: "center" }}>
            Список лабораторних робіт:
          </h2>
          {isAuthenticated ? (
            <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
              <NavLink
                to="/lab1"
                end
                className="button-lab"
              >
                Лабораторна робота 1
              </NavLink>
              <NavLink
                to="/lab2"
                end
                className="button-lab"
              >
                Лабораторна робота 2
              </NavLink>
              <NavLink
                to="/lab3"
                end
                className="button-lab"
              >
                Лабораторна робота 3
              </NavLink>
            </div>
          ) : (
            <div>
              <h3 style={{ color: "orange", textAlign: "center" }}>
                Увійдіть до аккаунту, щоб отримати доступ до лабораторних робіт!
              </h3>
              <div style={{ display: "flex", justifyContent: "center" }}>
                <button
                  className="button__login"
                  onClick={handleLogin}
                >
                  Увійти до аккаунту
                </button>
              </div>
            </div>
          )}
        </div>
      </>
    </PageLayout>
  );
};
