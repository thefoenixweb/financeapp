import React, { useEffect, useState, useRef } from 'react'
import { Link } from 'react-router-dom';
import { PortfolioGet } from '../../../Models/Portfolio.ts';
import { getCompanyProfile } from '../../../api';
import { CompanyProfile } from '../../../../company';

interface Props {
    portfolioValue: PortfolioGet;
    onDeleteClick: (symbol: string) => void;
}

const CardPortfolio = ({portfolioValue, onDeleteClick}: Props) => {
  const [companyProfile, setCompanyProfile] = useState<CompanyProfile | null>(null);
  const [showMenu, setShowMenu] = useState(false);
  const menuRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const fetchCompanyProfile = async () => {
      if (!portfolioValue.symbol) return;
      
      try {
        const result = await getCompanyProfile(portfolioValue.symbol);
        if (result && Array.isArray(result) && result.length > 0) {
          setCompanyProfile(result[0]);
        }
      } catch (error) {
        console.error('[CardPortfolio] Error fetching company profile for', portfolioValue.symbol,':', error);
      }
    };

    fetchCompanyProfile();
  }, [portfolioValue.symbol]);

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (menuRef.current && !menuRef.current.contains(event.target as Node)) {
        setShowMenu(false);
      }
    };

    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

  if (!portfolioValue || !portfolioValue.symbol) {
    return null;
  }

  const symbol = String(portfolioValue.symbol);

  return (
    <div className="bg-white p-6 rounded-lg shadow relative">
      {/* Kebab Menu Button */}
      <div className="absolute top-4 right-4" ref={menuRef}>
        <button
          onClick={() => setShowMenu(!showMenu)}
          className="p-2 hover:bg-gray-100 rounded-full transition-colors"
        >
          <svg
            className="w-5 h-5 text-neutral-600 dark:text-neutral-400 light-mode:text-gray-600"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={2}
              d="M12 5v.01M12 12v.01M12 19v.01M12 6a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2z"
            />
          </svg>
        </button>

        {/* Dropdown Menu */}
        {showMenu && (
          <div className="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg py-1 z-10">
            <button
              onClick={() => {
                setShowMenu(false);
                onDeleteClick(symbol);
              }}
              className="w-full text-left px-4 py-2 text-sm text-red-600 hover:bg-red-50 hover:text-red-700"
            >
              Delete
            </button>
          </div>
        )}
      </div>

      <div className="flex items-center space-x-4 mb-4 pr-8">
        {companyProfile?.image && (
          <img 
            src={companyProfile.image} 
            alt={`${portfolioValue.companyName} logo`}
            className="w-12 h-12 rounded-full flex-shrink-0"
          />
        )}
        <Link
          to={`/company/${symbol}/company-profile`}
          className="text-xl font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900 truncate flex-grow"
        >
          {portfolioValue.companyName}
        </Link>
      </div>
      
      <div className="space-y-2 mb-4">
        <div className="flex justify-between items-center text-neutral-700 dark:text-neutral-300 light-mode:text-gray-700">
          <span className="text-base">Symbol</span>
          <span className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
            {portfolioValue.symbol}
          </span>
        </div>
        <div className="flex justify-between items-center text-neutral-700 dark:text-neutral-300 light-mode:text-gray-700">
          <span className="text-base">Industry</span>
          <span className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
            {portfolioValue.industry}
          </span>
        </div>
        {portfolioValue.purchase && (
          <div className="flex justify-between items-center text-neutral-700 dark:text-neutral-300 light-mode:text-gray-700">
            <span className="text-base">Purchase Price</span>
            <span className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
              ${portfolioValue.purchase.toFixed(2)}
            </span>
          </div>
        )}
        <div className="flex justify-between items-center text-neutral-700 dark:text-neutral-300 light-mode:text-gray-700">
          <span className="text-base">Market Cap</span>
          <span className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
            ${(portfolioValue.marketCap / 1000000000).toFixed(2)}B
          </span>
        </div>
      </div>
    </div>
  );
};

export default React.memo(CardPortfolio);