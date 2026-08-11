import { api } from "./axios";

export type RegisterRequest = {
  userName: string;
  email: string;
  password: string;
};

export type LoginRequest = {
  email: string;
  password: string;
};

export type LoginResponse = {
    id: string;
    userName: string;
    email: string;
    token: string;
    mensagem: string;
}


export async function login(data: LoginRequest): Promise<LoginResponse> {
  const response = await api.post("/api/auth/login", data);

  return response.data;
}

export async function register(data: RegisterRequest) {

    const response = await api.post("/api/auth/registrar", data);
    return response.data;
}