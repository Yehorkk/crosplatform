import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { PageLoader } from "./components/page-loader";
import { AuthenticationGuard } from "./components/authentication-guard";
import { Route, Routes } from "react-router-dom";
import { CallbackPage } from "./pages/callback-page";
import { HomePage } from "./pages/home-page";
import { NotFoundPage } from "./pages/not-found-page";
import { ProfilePage } from "./pages/profile-page";
import { ProtectedPage } from "./pages/protected-page";
import { PublicPage } from "./pages/public-page";
import Lab1Page from "./pages/lab1-page";
import Lab3Page from "./pages/lab3-page";
import Lab2Page from "./pages/lab2-page";

export const App: React.FC = () => {
  const { isLoading } = useAuth0();

  if (isLoading) {
    return (
      <div className="page-layout">
        <PageLoader />
      </div>
    );
  }
  return (
    <Routes>
      <Route
        path="/"
        element={<HomePage />}
      />
      <Route
        path="/profile"
        element={<AuthenticationGuard component={ProfilePage} />}
      />
      <Route
        path="/public"
        element={<PublicPage />}
      />
      <Route
        path="/protected"
        element={<AuthenticationGuard component={ProtectedPage} />}
      />
      <Route
        path="/lab1"
        element={<AuthenticationGuard component={Lab1Page} />}
      />
      <Route
        path="/lab2"
        element={<AuthenticationGuard component={Lab2Page} />}
      />
      <Route
        path="/lab3"
        element={<AuthenticationGuard component={Lab3Page} />}
      />
      <Route
        path="/callback"
        element={<CallbackPage />}
      />
      <Route
        path="*"
        element={<NotFoundPage />}
      />
    </Routes>
  );
};
