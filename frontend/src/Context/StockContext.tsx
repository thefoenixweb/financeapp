import React, { createContext, useContext, useState, ReactNode } from 'react';
import axios from 'axios';

interface Stock {
  symbol: string;
  name: string;
  price: number;
  change: number;
  changePercent: number;
}

interface StockContextType {
  stocks: Stock[];
  loading: boolean;
  error: string | null;
  fetchStocks: () => Promise<void>;
  getStockBySymbol: (symbol: string) => Stock | undefined;
}

const StockContext = createContext<StockContextType | undefined>(undefined);

export const useStock = () => {
  const context = useContext(StockContext);
  if (!context) {
    throw new Error('useStock must be used within a StockProvider');
  }
  return context;
};

interface StockProviderProps {
  children: ReactNode;
}

export const StockProvider: React.FC<StockProviderProps> = ({ children }) => {
  const [stocks, setStocks] = useState<Stock[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchStocks = async () => {
    try {
      setLoading(true);
      setError(null);
      const API_KEY = import.meta.env.VITE_API_KEY;
      const BASE_URL = "https://financialmodelingprep.com/api/v3/";
      const response = await axios.get(`${BASE_URL}stock/list?apikey=${API_KEY}`);
      const stockData = response.data;
      const formattedStocks: Stock[] = stockData.map((stock: any) => ({
        symbol: stock.symbol,
        name: stock.name,
        price: stock.price,
        change: stock.changes,
        changePercent: stock.changesPercentage
      }));
      setStocks(formattedStocks);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  const getStockBySymbol = (symbol: string) => {
    return stocks.find(stock => stock.symbol === symbol);
  };

  return (
    <StockContext.Provider value={{ stocks, loading, error, fetchStocks, getStockBySymbol }}>
      {children}
    </StockContext.Provider>
  );
}; 