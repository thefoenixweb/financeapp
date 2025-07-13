import React, { createContext, useContext, useState, ReactNode } from 'react';
import axios from 'axios';

interface CompanyProfile {
  symbol: string;
  companyName: string;
  currency: string;
  exchange: string;
  industry: string;
  website: string;
  description: string;
  sector: string;
  country: string;
  fullTimeEmployees: number;
  phone: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  image: string;
  ipoDate: string;
  defaultImage: boolean;
  isEtf: boolean;
  isActivelyTrading: boolean;
  isAdr: boolean;
  isFund: boolean;
}

interface CompanyProfileContextType {
  profile: CompanyProfile | null;
  loading: boolean;
  error: string | null;
  fetchProfile: (symbol: string) => Promise<void>;
}

const CompanyProfileContext = createContext<CompanyProfileContextType | undefined>(undefined);

export const CompanyProfileProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [profile, setProfile] = useState<CompanyProfile | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchProfile = async (symbol: string) => {
    try {
      setLoading(true);
      setError(null);
      
      // First try to fetch the profile
      const response = await axios.get(`http://localhost:5167/api/CompanyProfile/${symbol}`);
      
      if (response.data) {
        setProfile(response.data);
      } else {
        // If profile doesn't exist, fetch it from FMP
        await axios.get(`http://localhost:5167/api/CompanyProfile/${symbol}/fetch`);
        // Then fetch the saved profile
        const savedResponse = await axios.get(`http://localhost:5167/api/CompanyProfile/${symbol}`);
        setProfile(savedResponse.data);
      }
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred while fetching the company profile');
    } finally {
      setLoading(false);
    }
  };

  return (
    <CompanyProfileContext.Provider value={{ profile, loading, error, fetchProfile }}>
      {children}
    </CompanyProfileContext.Provider>
  );
};

export const useCompanyProfile = () => {
  const context = useContext(CompanyProfileContext);
  if (context === undefined) {
    throw new Error('useCompanyProfile must be used within a CompanyProfileProvider');
  }
  return context;
}; 