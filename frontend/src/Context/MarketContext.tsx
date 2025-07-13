import React, { createContext, useContext, useState, ReactNode } from 'react';
import axios from 'axios';

interface MarketData {
  marketCap: number;
  volume: number;
  peRatio: number;
  dividendYield: number;
  sector: string;
  industry: string;
}

interface MarketContextType {
  marketData: Record<string, MarketData>;
  loading: boolean;
  error: string | null;
  fetchMarketData: (symbol: string) => Promise<void>;
  getMarketData: (symbol: string) => MarketData | undefined;
}

const MarketContext = createContext<MarketContextType | undefined>(undefined);

export const useMarket = () => {
  const context = useContext(MarketContext);
  if (!context) {
    throw new Error('useMarket must be used within a MarketProvider');
  }
  return context;
};

interface MarketProviderProps {
  children: ReactNode;
}

export const MarketProvider: React.FC<MarketProviderProps> = ({ children }) => {
  const [marketData, setMarketData] = useState<Record<string, MarketData>>({});
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchMarketData = async (symbol: string) => {
    try {
      setLoading(true);
      setError(null);
      const API_KEY = import.meta.env.VITE_API_KEY;
      const BASE_URL = "https://financialmodelingprep.com/api/v3/";
      const response = await axios.get(`${BASE_URL}quote/${symbol}?apikey=${API_KEY}`);
      const data = response.data[0];
      const formattedData: MarketData = {
        marketCap: data.marketCap,
        volume: data.volume,
        peRatio: data.pe,
        dividendYield: data.dividend,
        sector: data.sector,
        industry: data.industry
      };
      setMarketData(prev => ({ ...prev, [symbol]: formattedData }));
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  const getMarketData = (symbol: string) => {
    return marketData[symbol];
  };

  return (
    <MarketContext.Provider
      value={{
        marketData,
        loading,
        error,
        fetchMarketData,
        getMarketData,
      }}
    >
      {children}
    </MarketContext.Provider>
  );
}; 