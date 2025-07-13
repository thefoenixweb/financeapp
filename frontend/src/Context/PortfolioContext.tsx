import React, { createContext, useContext, useState, ReactNode, useEffect } from 'react';
import axios from 'axios';

const BACKEND_URL = 'http://localhost:5167/api';

interface PortfolioItem {
  symbol: string;
  shares: number;
  averagePrice: number;
  currentPrice: number;
}

interface PortfolioContextType {
  portfolio: PortfolioItem[];
  loading: boolean;
  error: string | null;
  addToPortfolio: (item: PortfolioItem) => void;
  removeFromPortfolio: (symbol: string) => void;
  updatePortfolio: (symbol: string, shares: number) => void;
  getPortfolioValue: () => number;
  fetchPortfolio: () => Promise<void>;
}

const PortfolioContext = createContext<PortfolioContextType | undefined>(undefined);

export const usePortfolio = () => {
  const context = useContext(PortfolioContext);
  if (!context) {
    throw new Error('usePortfolio must be used within a PortfolioProvider');
  }
  return context;
};

interface PortfolioProviderProps {
  children: ReactNode;
}

export const PortfolioProvider: React.FC<PortfolioProviderProps> = ({ children }) => {
  const [portfolio, setPortfolio] = useState<PortfolioItem[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchPortfolio = async () => {
    try {
      setLoading(true);
      setError(null);
      const token = localStorage.getItem('token');
      if (!token) {
        throw new Error('No authentication token found');
      }
      const response = await axios.get(`${BACKEND_URL}/portfolio`, {
        headers: {
          'Authorization': `Bearer ${token}`
        }
      });
      const portfolioData = response.data;
      const formattedPortfolio: PortfolioItem[] = portfolioData.map((item: any) => ({
        symbol: item.symbol,
        shares: item.purchase || 0,
        averagePrice: item.lastDiv || 0,
        currentPrice: item.marketCap || 0
      }));
      setPortfolio(formattedPortfolio);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchPortfolio();
  }, []);

  const addToPortfolio = (item: PortfolioItem) => {
    setPortfolio(prev => [...prev, item]);
  };

  const removeFromPortfolio = (symbol: string) => {
    setPortfolio(prev => prev.filter(item => item.symbol !== symbol));
  };

  const updatePortfolio = (symbol: string, shares: number) => {
    setPortfolio(prev =>
      prev.map(item =>
        item.symbol === symbol ? { ...item, shares } : item
      )
    );
  };

  const getPortfolioValue = () => {
    return portfolio.reduce((total, item) => {
      return total + (item.shares * item.currentPrice);
    }, 0);
  };

  return (
    <PortfolioContext.Provider
      value={{
        portfolio,
        loading,
        error,
        addToPortfolio,
        removeFromPortfolio,
        updatePortfolio,
        getPortfolioValue,
        fetchPortfolio,
      }}
    >
      {children}
    </PortfolioContext.Provider>
  );
}; 