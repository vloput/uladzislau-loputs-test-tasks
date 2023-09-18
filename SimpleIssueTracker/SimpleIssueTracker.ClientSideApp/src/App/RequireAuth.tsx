import { Navigate, useLocation } from "react-router-dom";
import { TokenInfo } from "../models/User/TokenInfo";
import { getTokenFromLocalStorage } from "../utils/authUtil";

export const RequireAuth = ({ children }: { children: JSX.Element }) => {
  let location = useLocation();

  const token: TokenInfo | null = getTokenFromLocalStorage();

  if (token && token.expires && token.expires.getTime() > new Date().getTime()) {
    return children;
  }
  
  return <Navigate to="/login" state={{ from: location }} replace />;
};
