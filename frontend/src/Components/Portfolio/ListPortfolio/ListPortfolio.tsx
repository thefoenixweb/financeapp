import React from 'react';
import { Link } from 'react-router-dom';
import { PortfolioGet } from '../../../Models/Portfolio.ts';

interface Props {
    portfolioValues: PortfolioGet[];
    onPortfolioDelete: (symbol: string) => void;
}

const ListPortfolio = ({ portfolioValues, onPortfolioDelete }: Props) => {
  return (
    <div className="bg-white rounded-lg shadow overflow-hidden">
      <div className="p-6">
        <h2 className="text-2xl font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900 mb-4">
          My Portfolio
        </h2>
        <div className="space-y-4">
          {portfolioValues.map((portfolio) => (
            <div
              key={portfolio.symbol}
              className="flex items-center justify-between p-4 bg-neutral-50 dark:bg-neutral-800 light-mode:bg-gray-50 rounded-lg"
            >
              <div className="flex items-center space-x-4">
                <div>
                  <Link
                    to={`/company/${portfolio.symbol}/company-profile`}
                    className="text-lg font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900 hover:text-blue-600 dark:hover:text-blue-400"
                  >
                    {portfolio.companyName}
                  </Link>
                  <p className="text-sm text-neutral-600 dark:text-neutral-400 light-mode:text-gray-600">
                    {portfolio.symbol}
                  </p>
                </div>
              </div>
              <div className="flex items-center space-x-4">
                <div className="text-right">
                  <p className="text-sm text-neutral-600 dark:text-neutral-400 light-mode:text-gray-600">
                    Industry
                  </p>
                  <p className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
                    {portfolio.industry}
                  </p>
                </div>
                {portfolio.purchase && (
                  <div className="text-right">
                    <p className="text-sm text-neutral-600 dark:text-neutral-400 light-mode:text-gray-600">
                      Purchase Price
                    </p>
                    <p className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
                      ${portfolio.purchase.toFixed(2)}
                    </p>
                  </div>
                )}
                <div className="text-right">
                  <p className="text-sm text-neutral-600 dark:text-neutral-400 light-mode:text-gray-600">
                    Market Cap
                  </p>
                  <p className="text-base font-semibold text-neutral-900 dark:text-neutral-100 light-mode:text-gray-900">
                    ${(portfolio.marketCap / 1000000000).toFixed(2)}B
                  </p>
                </div>
                <button
                  onClick={() => onPortfolioDelete(portfolio.symbol)}
                  className="p-2 text-red-600 hover:bg-red-50 rounded-full transition-colors"
                >
                  <svg
                    className="w-5 h-5"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                    />
                  </svg>
                </button>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default React.memo(ListPortfolio);