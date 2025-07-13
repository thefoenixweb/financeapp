import axios from 'axios';

const BACKEND_URL = 'http://localhost:5167/api/account';

export interface LoginDto {
  username: string;
  password: string;
}

export interface RegisterDto {
  username: string;
  email: string;
  password: string;
}

export interface AuthResponse {
  userName: string;
  email: string;
  token: string;
}

export const login = async (data: LoginDto): Promise<AuthResponse> => {
  const response = await axios.post(`${BACKEND_URL}/login`, data);
  return response.data;
};

export const register = async (data: RegisterDto): Promise<AuthResponse> => {
  const response = await axios.post(`${BACKEND_URL}/register`, data);
  return response.data;
}; 