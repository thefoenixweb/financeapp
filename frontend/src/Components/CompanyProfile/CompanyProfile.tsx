import React from 'react'
import { formatLargeMonetaryNumber, formatRatio, formatLargeNonMonetaryNumber } from '../../Helpers/NumberFormatting.tsx';
import { FaBuilding, FaPhone, FaGlobe, FaChartLine, FaUsers, FaCalendarAlt } from 'react-icons/fa';
import { useCompany } from '../../Context/CompanyContext';

const CompanyProfile = () => {
  const { ticker, companyData, isLoading } = useCompany();

  if (isLoading) {
    return <div>Loading company profile...</div>;
  }

  if (!ticker || !companyData) {
    return <div>No company data available. Please select a ticker.</div>;
  }

  const {
    companyName,
    symbol,
    price,
    changes,
    currency,
    image,
    defaultImage,
    mktCap,
    volAvg,
    beta,
    lastDiv,
    range,
    isEtf,
    isActivelyTrading,
    isAdr,
    isFund,
    description,
    industry,
    sector,
    ceo,
    fullTimeEmployees,
    website,
    ipoDate,
    dcf,
    dcfDiff,
    address,
    city,
    state,
    zip,
    phone,
    exchange,
    exchangeShortName,
    isin,
    cik,
    counter
  } = companyData;

  return (
    <div className="p-6 space-y-6">
      {/* 1. Top Header: Company Identification & Quick Stock Glance */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow flex justify-between items-start light-mode:bg-white">
        <div>
          <h1 className="text-3xl font-bold text-neutral-100 light-mode:text-neutral-900">{companyName}</h1>
          <p className="text-xl text-neutral-400 light-mode:text-neutral-600">{symbol}</p>
        </div>
        <div className="text-right">
          <p className="text-3xl font-bold text-neutral-100 light-mode:text-neutral-900">
            {formatLargeMonetaryNumber(price)} {currency}
          </p>
          <p className={`text-lg ${changes >= 0 ? 'text-green-500' : 'text-red-500'}`}>
            {changes >= 0 ? '+' : ''}{changes.toFixed(2)} ({((changes / price) * 100).toFixed(2)}%)
          </p>
          {!defaultImage && image && (
            <img src={image} alt={`${companyName} logo`} className="h-16 w-16 mt-2" />
          )}
        </div>
      </div>

      {/* 2. Key Stock Performance & Market Snapshot */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow grid grid-cols-2 md:grid-cols-3 lg:grid-cols-6 gap-4 light-mode:bg-white">
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">Market Cap</p>
          <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(mktCap)}</p>
        </div>
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">Avg Volume</p>
          <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeNonMonetaryNumber(volAvg)}</p>
        </div>
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">Beta</p>
          <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{beta.toFixed(2)}</p>
        </div>
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">Last Dividend</p>
          <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(lastDiv)}</p>
        </div>
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">52-Week Range</p>
          <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{range}</p>
        </div>
        <div className="p-4 bg-neutral-700 rounded-lg light-mode:bg-gray-100">
          <p className="text-sm text-neutral-400 light-mode:text-gray-600">Status</p>
          <div className="flex flex-wrap gap-2 mt-2">
            {isEtf && <span className="px-2 py-1 bg-blue-500 text-white text-xs rounded">ETF</span>}
            {isActivelyTrading && <span className="px-2 py-1 bg-green-500 text-white text-xs rounded">Active</span>}
            {isAdr && <span className="px-2 py-1 bg-purple-500 text-white text-xs rounded">ADR</span>}
            {isFund && <span className="px-2 py-1 bg-yellow-500 text-white text-xs rounded">Fund</span>}
          </div>
        </div>
      </div>

      {/* 3. Company Overview & Business Description */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
        <h2 className="text-2xl font-bold mb-4 text-neutral-100 light-mode:text-neutral-900">About {companyName}</h2>
        <p className="text-neutral-300 light-mode:text-neutral-700 mb-6">{description}</p>
        <div className="grid grid-cols-2 md:grid-cols-3 gap-4">
          <div className="flex items-center space-x-2">
            <FaBuilding className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Industry</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{industry}</p>
            </div>
          </div>
          <div className="flex items-center space-x-2">
            <FaChartLine className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Sector</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{sector}</p>
            </div>
          </div>
          <div className="flex items-center space-x-2">
            <FaUsers className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">CEO</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{ceo}</p>
            </div>
          </div>
          <div className="flex items-center space-x-2">
            <FaUsers className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Employees</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{formatLargeNonMonetaryNumber(Number(fullTimeEmployees))}</p>
            </div>
          </div>
          <div className="flex items-center space-x-2">
            <FaGlobe className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Website</p>
              <a href={website} target="_blank" rel="noopener noreferrer" className="text-primary-gold hover:underline light-mode:text-primary-green">
                {website}
              </a>
            </div>
          </div>
          <div className="flex items-center space-x-2">
            <FaCalendarAlt className="text-neutral-400" />
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">IPO Date</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{ipoDate}</p>
            </div>
          </div>
        </div>
      </div>

      {/* 4. Valuation & Contact Information */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {/* Valuation Details */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-xl font-bold mb-4 text-neutral-100 light-mode:text-neutral-900">Valuation</h2>
          <div className="space-y-4">
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Discounted Cash Flow (DCF)</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(dcf)}</p>
            </div>
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">DCF Difference</p>
              <p className={`text-xl font-bold ${dcfDiff >= 0 ? 'text-green-500' : 'text-red-500'}`}>
                {dcfDiff >= 0 ? '+' : ''}{formatLargeMonetaryNumber(dcfDiff)}
              </p>
            </div>
          </div>
        </div>

        {/* Headquarters & Contact */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-xl font-bold mb-4 text-neutral-100 light-mode:text-neutral-900">Headquarters</h2>
          <div className="space-y-4">
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Address</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">
                {address}<br />
                {city}, {state} {zip}
              </p>
            </div>
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Phone</p>
              <a href={`tel:${phone}`} className="text-primary-gold hover:underline light-mode:text-primary-green">
                {phone}
              </a>
            </div>
            <div>
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Exchange</p>
              <p className="text-neutral-100 light-mode:text-neutral-900">{exchangeShortName}</p>
            </div>
            <div className="grid grid-cols-2 gap-4">
              <div>
                <p className="text-sm text-neutral-400 light-mode:text-gray-600">ISIN</p>
                <p className="text-neutral-100 light-mode:text-neutral-900">{isin}</p>
              </div>
              <div>
                <p className="text-sm text-neutral-400 light-mode:text-gray-600">CIK</p>
                <p className="text-neutral-100 light-mode:text-neutral-900">{cik}</p>
              </div>
            </div>
            {counter && (
              <div>
                <p className="text-sm text-neutral-400 light-mode:text-gray-600">Counter</p>
                <p className="text-neutral-100 light-mode:text-neutral-900">{counter}</p>
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default CompanyProfile;