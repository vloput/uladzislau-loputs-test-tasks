import { ACCESS_TOKEN_STORAGE_KEY } from "../constants";
import { TokenInfo } from "../models/User/TokenInfo";

export function getTokenFromLocalStorage(): TokenInfo | null {
  const tokenString = localStorage.getItem(ACCESS_TOKEN_STORAGE_KEY) as string;

  if (!tokenString) {
    return null;
  }

  let token: TokenInfo = JSON.parse(tokenString);

  token.expires = token.expires && new Date(token.expires);

  return token;
}