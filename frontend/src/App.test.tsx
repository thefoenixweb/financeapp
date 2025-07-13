import { describe, it, expect, vi } from 'vitest';
import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import App from './App';

// Mock the context providers to avoid complex setup
vi.mock('./Context/useAuth', () => ({
  UserProvider: ({ children }: { children: React.ReactNode }) => <div data-testid="user-provider">{children}</div>
}));

vi.mock('./Context/ThemeContext', () => ({
  ThemeProvider: ({ children }: { children: React.ReactNode }) => <div data-testid="theme-provider">{children}</div>
}));

vi.mock('./Context/StockContext', () => ({
  StockProvider: ({ children }: { children: React.ReactNode }) => <div data-testid="stock-provider">{children}</div>
}));

vi.mock('./Context/PortfolioContext', () => ({
  PortfolioProvider: ({ children }: { children: React.ReactNode }) => <div data-testid="portfolio-provider">{children}</div>
}));



vi.mock('./Context/MarketContext', () => ({
  MarketProvider: ({ children }: { children: React.ReactNode }) => <div data-testid="market-provider">{children}</div>
}));

vi.mock('./Components/Sidebar/Sidebar', () => ({
  default: () => <div data-testid="sidebar">Sidebar</div>
}));

vi.mock('./Components/ErrorBoundary', () => ({
  default: ({ children }: { children: React.ReactNode }) => <div data-testid="error-boundary">{children}</div>
}));

describe('App Component', () => {
  it('renders without crashing', () => {
    render(
      <BrowserRouter>
        <App />
      </BrowserRouter>
    );
    
    expect(screen.getByTestId('error-boundary')).toBeInTheDocument();
    expect(screen.getByTestId('theme-provider')).toBeInTheDocument();
    expect(screen.getByTestId('user-provider')).toBeInTheDocument();
    expect(screen.getByTestId('stock-provider')).toBeInTheDocument();
    expect(screen.getByTestId('portfolio-provider')).toBeInTheDocument();
    expect(screen.getByTestId('market-provider')).toBeInTheDocument();
    expect(screen.getByTestId('sidebar')).toBeInTheDocument();
  });

  it('renders main content area', () => {
    render(
      <BrowserRouter>
        <App />
      </BrowserRouter>
    );
    
    expect(screen.getByRole('main')).toBeInTheDocument();
  });
}); 