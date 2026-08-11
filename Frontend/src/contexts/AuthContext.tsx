import {
  createContext,
  useContext,
  useState,
  type ReactNode,
} from "react";

import type { LoginResponse } from "../api/auth";

type User = {
  id: string;
  userName: string;
  email: string;
};

type AuthContextData = {
  token: string | null;
  user: User | null;
  login: (response: LoginResponse) => void;
  logout: () => void;
};

type AuthProviderProps = {
  children: ReactNode;
};

const TOKEN_KEY = "access_token";
const USER_KEY = "user";

const AuthContext = createContext<AuthContextData | undefined>(
  undefined
);

export function AuthProvider({ children }: AuthProviderProps) {
  const [token, setToken] = useState<string | null>(() => {
    return localStorage.getItem(TOKEN_KEY);
  });

  const [user, setUser] = useState<User | null>(() => {
    const storedUser = localStorage.getItem(USER_KEY);

    return storedUser ? JSON.parse(storedUser) : null;
  });

  function login(response: LoginResponse) {
    const userData: User = {
      id: response.id,
      userName: response.userName,
      email: response.email,
    };

    localStorage.setItem(TOKEN_KEY, response.token);
    localStorage.setItem(USER_KEY, JSON.stringify(userData));

    setToken(response.token);
    setUser(userData);
  }

  function logout() {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);

    setToken(null);
    setUser(null);
  }

  return (
    <AuthContext.Provider
      value={{
        token,
        user,
        login,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error(
      "useAuth deve ser usado dentro de AuthProvider"
    );
  }

  return context;
}