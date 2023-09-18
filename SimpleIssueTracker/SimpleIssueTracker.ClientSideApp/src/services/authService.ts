import { ACCESS_TOKEN_STORAGE_KEY } from "../constants";
import { TokenInfo } from "../models/User/TokenInfo";
import { TokenPayload } from "../models/User/TokenPayload";

export class AuthService {
  constructor(
    private readonly serviceUrl: string,
  ) { }

  public async login(username: string, password: string) {
    const response = await fetch(`${this.serviceUrl}/login`, {
      method: 'POST',
      body: JSON.stringify({
        username,
        password,
      }),
      headers: {
        'Content-Type': 'application/json',
      }
    });

    if (!response.ok) {
      throw 'Unable to authorize';
    }

    const result = await response.json();

    let tokenInfo: TokenInfo = result;

    // Getting info from the token payload
    const payload: TokenPayload = JSON.parse(window.atob(tokenInfo.accessToken.split('.')[1]));
    tokenInfo.expires = new Date(payload.exp * 1000);

    localStorage.setItem(ACCESS_TOKEN_STORAGE_KEY, JSON.stringify(tokenInfo));
  };
}
