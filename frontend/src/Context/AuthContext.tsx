import React, { createContext, useContext, useState, ReactNode } from 'react';
import * as AuthService from '../Services/AuthService';

interface AuthContextType {
  user: string | null;
  token: string | null;
  login: (data: AuthService.LoginDto) => Promise<void>;
  register: (data: AuthService.RegisterDto) => Promise<void>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<string | null>(localStorage.getItem('user'));
  const [token, setToken] = useState<string | null>(localStorage.getItem('token'));

  const login = async (data: AuthService.LoginDto) => {
    const res = await AuthService.login(data);
    setUser(res.userName);
    setToken(res.token);
    localStorage.setItem('user', res.userName);
    localStorage.setItem('token', res.token);
  };

  const register = async (data: AuthService.RegisterDto) => {
    const res = await AuthService.register(data);
    setUser(res.userName);
    setToken(res.token);
    localStorage.setItem('user', res.userName);
    localStorage.setItem('token', res.token);
  };

  const logout = () => {
    setUser(null);
    setToken(null);
    localStorage.removeItem('user');
    localStorage.removeItem('token');
  };

  return (
    <AuthContext.Provider value={{ user, token, login, register, logout }}>
      {children}
    </AuthContext.Provider>
  );
}; 