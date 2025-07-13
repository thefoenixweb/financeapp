import { describe, it, expect, vi, beforeEach, afterEach } from 'vitest';
import axios from 'axios';
import {
  searchCompanies,
  getCompanyProfile,
  getKeyMetrics,
  getPortfolio,
  addToPortfolio
} from './api';

// Mock axios
vi.mock('axios');
const mockedAxios = axios as any;

// Mock localStorage
const localStorageMock = {
  getItem: vi.fn(),
  setItem: vi.fn(),
  removeItem: vi.fn(),
  clear: vi.fn(),
};
Object.defineProperty(window, 'localStorage', {
  value: localStorageMock
});

describe('API Functions', () => {
  beforeEach(() => {
    vi.clearAllMocks();
    localStorageMock.getItem.mockReturnValue('test-token');
  });

  afterEach(() => {
    vi.resetAllMocks();
  });

  describe('searchCompanies', () => {
    it('should successfully search companies', async () => {
      const mockResponse = {
        data: {
          data: [
            { symbol: 'AAPL', name: 'Apple Inc.' },
            { symbol: 'GOOGL', name: 'Alphabet Inc.' }
          ]
        }
      };
      mockedAxios.get.mockResolvedValueOnce(mockResponse);

      const result = await searchCompanies('apple');
      
      expect(mockedAxios.get).toHaveBeenCalledWith(
        expect.stringContaining('https://financialmodelingprep.com/api/v3/search')
      );
      expect(result).toEqual(mockResponse);
    });

    it('should handle axios errors', async () => {
      const errorMessage = 'Network error';
      const axiosError = new Error(errorMessage);
      (axiosError as any).isAxiosError = true;
      mockedAxios.get.mockRejectedValueOnce(axiosError);

      const result = await searchCompanies('apple');
      
      expect(result).toBe('An expected error has occured.');
    });
  });

  describe('getCompanyProfile', () => {
    it('should successfully get company profile', async () => {
      const mockResponse = { data: { symbol: 'AAPL', name: 'Apple Inc.' } };
      mockedAxios.get.mockResolvedValueOnce({}); // First call (fetch)
      mockedAxios.get.mockResolvedValueOnce(mockResponse); // Second call (get)

      const result = await getCompanyProfile('AAPL');
      
      expect(mockedAxios.get).toHaveBeenCalledWith(
        'http://localhost:5167/api/company-profile/AAPL/fetch'
      );
      expect(mockedAxios.get).toHaveBeenCalledWith(
        'http://localhost:5167/api/company-profile/AAPL'
      );
      expect(mockedAxios.get).toHaveBeenCalledTimes(2);
      expect(result).toEqual(mockResponse.data);
    });

    it('should handle errors and return null', async () => {
      mockedAxios.get.mockRejectedValueOnce(new Error('API error'));

      const result = await getCompanyProfile('AAPL');
      
      expect(result).toBeNull();
    });
  });

  describe('getKeyMetrics', () => {
    it('should successfully get key metrics', async () => {
      const mockData = [{ revenue: 1000000, netIncome: 500000 }];
      mockedAxios.get.mockResolvedValueOnce({ data: mockData });

      const result = await getKeyMetrics('AAPL');
      
      expect(mockedAxios.get).toHaveBeenCalledWith(
        'http://localhost:5167/api/financial-statement/fmp/income/AAPL'
      );
      expect(result).toEqual(mockData);
    });

    it('should handle errors and return empty array', async () => {
      mockedAxios.get.mockRejectedValueOnce(new Error('API error'));

      const result = await getKeyMetrics('AAPL');
      
      expect(result).toEqual([]);
    });
  });

  describe('getPortfolio', () => {
    it('should successfully get portfolio with token', async () => {
      const mockData = { data: [{ symbol: 'AAPL', shares: 10 }] };
      mockedAxios.get.mockResolvedValueOnce(mockData);

      const result = await getPortfolio();
      
      expect(mockedAxios.get).toHaveBeenCalledWith(
        'http://localhost:5167/api/portfolio',
        {
          headers: {
            'Authorization': 'Bearer test-token'
          }
        }
      );
      expect(result).toEqual(mockData);
    });

    it('should handle missing token', async () => {
      localStorageMock.getItem.mockReturnValue(null);

      const result = await getPortfolio();
      
      expect(result).toEqual({ data: [] });
    });
  });

  describe('addToPortfolio', () => {
    it('should successfully add to portfolio', async () => {
      const mockData = { data: { message: 'Added to portfolio' } };
      mockedAxios.post.mockResolvedValueOnce(mockData);

      const result = await addToPortfolio('AAPL');
      
      expect(mockedAxios.post).toHaveBeenCalledWith(
        'http://localhost:5167/api/portfolio?symbol=AAPL',
        {},
        {
          headers: {
            'Authorization': 'Bearer test-token'
          }
        }
      );
      expect(result).toEqual(mockData);
    });

    it('should handle missing token', async () => {
      localStorageMock.getItem.mockReturnValue(null);

      await expect(addToPortfolio('AAPL')).rejects.toThrow('No authentication token found');
    });
  });
}); 