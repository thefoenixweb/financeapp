import React, { createContext, useContext, useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../api'; // remove addToPortfolio

interface CompanyContextType {
    ticker: string | undefined;
    companyData: CompanyProfile | null;
    isLoading: boolean;
}

const CompanyContext = createContext<CompanyContextType | undefined>(undefined);

export const CompanyProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const navigate = useNavigate();
    const params = useParams<{ ticker: string }>();
    const [ticker, setTicker] = useState<string | undefined>();
    const [companyData, setCompanyData] = useState<CompanyProfile | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        if (!params.ticker) {
            navigate('/search');
            return;
        }

        if (params.ticker === '[object Object]') {
            navigate('/search');
            return;
        }
        
        try {
            const parsedTicker = JSON.parse(params.ticker);
            const extractedTicker = typeof parsedTicker === 'object' && parsedTicker !== null && 'symbol' in parsedTicker 
                ? parsedTicker.symbol 
                : params.ticker;
            
            setTicker(extractedTicker);
        } catch {
            setTicker(params.ticker);
        }
    }, [params.ticker, navigate]);

    useEffect(() => {
        if (!ticker) return;

        const fetchCompanyData = async () => {
            if (!ticker) {
                navigate('/search');
                return;
            }

            try {
                setIsLoading(true);
                const result = await getCompanyProfile(ticker);
                if (result) {
                    setCompanyData(result);
                } else {
                    navigate('/search');
                }
            } catch (error) {
                console.error('Error fetching company data:', error);
                navigate('/search');
            } finally {
                setIsLoading(false);
            }
        };

        fetchCompanyData();
    }, [ticker, navigate]);

    return (
        <CompanyContext.Provider value={{ ticker, companyData, isLoading }}>
            {children}
        </CompanyContext.Provider>
    );
};

export const useCompany = () => {
    const context = useContext(CompanyContext);
    if (context === undefined) {
        throw new Error('useCompany must be used within a CompanyProvider');
    }
    return context;
};