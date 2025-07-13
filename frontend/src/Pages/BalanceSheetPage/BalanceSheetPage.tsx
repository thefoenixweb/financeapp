import React, { useEffect, useState } from 'react';
import { CompanyBalanceSheet } from '../../../company';
import Spinner from '../../Components/Spinner/Spinner.tsx';
import { formatLargeMonetaryNumber, formatRatio, formatLargeNonMonetaryNumber } from '../../Helpers/NumberFormatting.tsx';
import { useCompany } from '../../Context/CompanyContext';
import { getBalanceSheet } from '../../api';
import { Bar, Pie } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ArcElement,
} from 'chart.js';

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ArcElement
);

interface Props {}

const BalanceSheetPage: React.FC = (props: Props) => {
  const { ticker, companyData } = useCompany();
  const [balanceSheetData, setBalanceSheetData] = useState<CompanyBalanceSheet | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBalanceSheet = async () => {
      if (!ticker) return;
      
      try {
        setIsLoading(true);
        setError(null);
        const result = await getBalanceSheet(ticker);
        if (result && result.length > 0) {
          setBalanceSheetData(result[0]);
        } else {
          setError('No balance sheet data available');
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch balance sheet data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchBalanceSheet();
  }, [ticker]);

  if (isLoading) {
    return <Spinner />;
  }

  if (error || !balanceSheetData || !companyData) {
    return <div className="p-6 text-red-500">{error || 'No data available'}</div>;
  }

  const {
    symbol,
    period,
    calendarYear,
    date,
    fillingDate,
    acceptedDate,
    reportedCurrency,
    cik,
    finalLink,
    cashAndCashEquivalents,
    shortTermInvestments,
    cashAndShortTermInvestments,
    netReceivables,
    inventory,
    otherCurrentAssets,
    totalCurrentAssets,
    propertyPlantEquipmentNet,
    goodwill,
    intangibleAssets,
    goodwillAndIntangibleAssets,
    longTermInvestments,
    taxAssets,
    otherNonCurrentAssets,
    totalNonCurrentAssets,
    otherAssets,
    totalAssets,
    accountPayables,
    shortTermDebt,
    taxPayables,
    deferredRevenue,
    otherCurrentLiabilities,
    totalCurrentLiabilities,
    longTermDebt,
    deferredRevenueNonCurrent,
    deferredTaxLiabilitiesNonCurrent,
    otherNonCurrentLiabilities,
    totalNonCurrentLiabilities,
    otherLiabilities,
    capitalLeaseObligations,
    totalLiabilities,
    preferredStock,
    commonStock,
    retainedEarnings,
    accumulatedOtherComprehensiveIncomeLoss,
    othertotalStockholdersEquity,
    totalStockholdersEquity,
    totalEquity,
    totalLiabilitiesAndStockholdersEquity,
    minorityInterest,
    totalLiabilitiesAndTotalEquity,
    totalInvestments,
    totalDebt,
    netDebt
  } = balanceSheetData;

  // Calculate key ratios
  const currentRatio = totalCurrentAssets / totalCurrentLiabilities;
  const debtToEquityRatio = totalDebt / totalStockholdersEquity;
  const cashToTotalAssets = (cashAndCashEquivalents + shortTermInvestments) / totalAssets;

  // Chart data for Accounting Equation
  const accountingEquationData = {
    labels: ['Liabilities', 'Equity'],
    datasets: [
      {
        data: [totalLiabilities, totalStockholdersEquity],
        backgroundColor: ['#4CAF50', '#9C27B0'],
        borderColor: ['#388E3C', '#7B1FA2'],
        borderWidth: 1,
      },
    ],
  };

  // Chart data for Assets Breakdown
  const assetsData = {
    labels: ['Current Assets', 'Non-Current Assets'],
    datasets: [
      {
        label: 'Assets Breakdown',
        data: [totalCurrentAssets, totalNonCurrentAssets],
        backgroundColor: ['#2196F3', '#1976D2'],
        borderColor: ['#1976D2', '#0D47A1'],
        borderWidth: 1,
      },
    ],
  };

  // Chart data for Liabilities & Equity Breakdown
  const liabilitiesEquityData = {
    labels: ['Current Liabilities', 'Non-Current Liabilities', 'Equity'],
    datasets: [
      {
        label: 'Liabilities & Equity Breakdown',
        data: [totalCurrentLiabilities, totalNonCurrentLiabilities, totalStockholdersEquity],
        backgroundColor: ['#FF9800', '#F57C00', '#9C27B0'],
        borderColor: ['#F57C00', '#E65100', '#7B1FA2'],
        borderWidth: 1,
      },
    ],
  };

  // Chart options
  const chartOptions = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top' as const,
      },
      title: {
        display: true,
        text: 'Financial Breakdown',
      },
    },
  };

  return (
    <div className="p-6">
      {/* 1. Top Header: Company & Report Identification */}
      <div className="bg-neutral-800 p-4 rounded-lg shadow mb-6 flex flex-wrap justify-between items-center light-mode:bg-white">
        <div>
          <h2 className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{symbol} <span className="text-neutral-400 text-base light-mode:text-gray-600">({companyData.companyName})</span></h2>
          <p className="text-sm text-neutral-400 light-mode:text-gray-500">Central Index Key: {cik}</p>
        </div>
        <div className="text-right text-neutral-100 light-mode:text-neutral-900">
          <p className="text-lg font-semibold">Report Period: {period} {calendarYear}</p>
          <p>As of: {date}</p>
          <p>Filed: {fillingDate}</p>
          <p>Currency: {reportedCurrency}</p>
          {finalLink && (
            <a href={finalLink} target="_blank" rel="noopener noreferrer" className="text-primary-gold hover:underline text-sm light-mode:text-blue-500 light-mode:hover:text-blue-700">
              Source Document <i className="fas fa-external-link-alt"></i>
            </a>
          )}
        </div>
      </div>

      {/* 2. The Accounting Equation Visualizer */}
      <div className="bg-neutral-800 p-6 rounded-lg shadow mb-6 light-mode:bg-white">
        <h2 className="text-xl font-semibold mb-4 text-center text-neutral-100 light-mode:text-neutral-900">The Accounting Equation</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="flex items-center justify-center">
            <div className="w-full max-w-md">
              <Pie data={accountingEquationData} options={chartOptions} />
            </div>
          </div>
          <div className="flex flex-col justify-center space-y-4">
            <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-blue-50">
              <h3 className="text-lg font-semibold mb-2 text-neutral-100 light-mode:text-neutral-900">Total Assets</h3>
              <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(totalAssets)}</p>
            </div>
            <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-green-50">
              <h3 className="text-lg font-semibold mb-2 text-neutral-100 light-mode:text-neutral-900">Total Liabilities</h3>
              <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(totalLiabilities)}</p>
            </div>
            <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-purple-50">
              <h3 className="text-lg font-semibold mb-2 text-neutral-100 light-mode:text-neutral-900">Total Equity</h3>
              <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(totalStockholdersEquity)}</p>
            </div>
          </div>
        </div>
        <div className="text-center mt-4 text-sm text-neutral-400 light-mode:text-gray-600">
          Verification: {formatLargeMonetaryNumber(totalLiabilitiesAndStockholdersEquity)} = {formatLargeMonetaryNumber(totalAssets)}
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* 3. Assets Breakdown */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-xl font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Assets</h2>
          <div className="mb-6">
            <Bar data={assetsData} options={chartOptions} />
          </div>
          
          {/* Current Assets */}
          <div className="mb-6">
            <h3 className="text-lg font-medium mb-3 text-neutral-100 light-mode:text-neutral-900">Current Assets</h3>
            <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
              <p className="flex justify-between"><span>Cash & Equivalents:</span> <span>{formatLargeMonetaryNumber(cashAndCashEquivalents)}</span></p>
              <p className="flex justify-between"><span>Short-Term Investments:</span> <span>{formatLargeMonetaryNumber(shortTermInvestments)}</span></p>
              <p className="flex justify-between"><span>Net Receivables:</span> <span>{formatLargeMonetaryNumber(netReceivables)}</span></p>
              <p className="flex justify-between"><span>Inventory:</span> <span>{formatLargeMonetaryNumber(inventory)}</span></p>
              <p className="flex justify-between"><span>Other Current Assets:</span> <span>{formatLargeMonetaryNumber(otherCurrentAssets)}</span></p>
              <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
              <p className="flex justify-between font-bold"><span>Total Current Assets:</span> <span>{formatLargeMonetaryNumber(totalCurrentAssets)}</span></p>
            </div>
          </div>

          {/* Non-Current Assets */}
          <div>
            <h3 className="text-lg font-medium mb-3 text-neutral-100 light-mode:text-neutral-900">Non-Current Assets</h3>
            <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
              <p className="flex justify-between"><span>Property, Plant & Equipment:</span> <span>{formatLargeMonetaryNumber(propertyPlantEquipmentNet)}</span></p>
              <p className="flex justify-between"><span>Goodwill & Intangibles:</span> <span>{formatLargeMonetaryNumber(goodwillAndIntangibleAssets)}</span></p>
              <p className="flex justify-between"><span>Long-Term Investments:</span> <span>{formatLargeMonetaryNumber(longTermInvestments)}</span></p>
              <p className="flex justify-between"><span>Tax Assets:</span> <span>{formatLargeMonetaryNumber(taxAssets)}</span></p>
              <p className="flex justify-between"><span>Other Non-Current Assets:</span> <span>{formatLargeMonetaryNumber(otherNonCurrentAssets)}</span></p>
              <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
              <p className="flex justify-between font-bold"><span>Total Non-Current Assets:</span> <span>{formatLargeMonetaryNumber(totalNonCurrentAssets)}</span></p>
            </div>
          </div>
        </div>

        {/* 4. Liabilities & Equity Breakdown */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-xl font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Liabilities & Equity</h2>
          <div className="mb-6">
            <Bar data={liabilitiesEquityData} options={chartOptions} />
          </div>
          
          {/* Current Liabilities */}
          <div className="mb-6">
            <h3 className="text-lg font-medium mb-3 text-neutral-100 light-mode:text-neutral-900">Current Liabilities</h3>
            <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
              <p className="flex justify-between"><span>Accounts Payable:</span> <span>{formatLargeMonetaryNumber(accountPayables)}</span></p>
              <p className="flex justify-between"><span>Short-Term Debt:</span> <span>{formatLargeMonetaryNumber(shortTermDebt)}</span></p>
              <p className="flex justify-between"><span>Tax Payables:</span> <span>{formatLargeMonetaryNumber(taxPayables)}</span></p>
              <p className="flex justify-between"><span>Deferred Revenue:</span> <span>{formatLargeMonetaryNumber(deferredRevenue)}</span></p>
              <p className="flex justify-between"><span>Other Current Liabilities:</span> <span>{formatLargeMonetaryNumber(otherCurrentLiabilities)}</span></p>
              <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
              <p className="flex justify-between font-bold"><span>Total Current Liabilities:</span> <span>{formatLargeMonetaryNumber(totalCurrentLiabilities)}</span></p>
            </div>
          </div>

          {/* Non-Current Liabilities */}
          <div className="mb-6">
            <h3 className="text-lg font-medium mb-3 text-neutral-100 light-mode:text-neutral-900">Non-Current Liabilities</h3>
            <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
              <p className="flex justify-between"><span>Long-Term Debt:</span> <span>{formatLargeMonetaryNumber(longTermDebt)}</span></p>
              <p className="flex justify-between"><span>Deferred Revenue (Non-Current):</span> <span>{formatLargeMonetaryNumber(deferredRevenueNonCurrent)}</span></p>
              <p className="flex justify-between"><span>Deferred Tax Liabilities:</span> <span>{formatLargeMonetaryNumber(deferredTaxLiabilitiesNonCurrent)}</span></p>
              <p className="flex justify-between"><span>Other Non-Current Liabilities:</span> <span>{formatLargeMonetaryNumber(otherNonCurrentLiabilities)}</span></p>
              <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
              <p className="flex justify-between font-bold"><span>Total Non-Current Liabilities:</span> <span>{formatLargeMonetaryNumber(totalNonCurrentLiabilities)}</span></p>
            </div>
          </div>

          {/* Equity */}
          <div>
            <h3 className="text-lg font-medium mb-3 text-neutral-100 light-mode:text-neutral-900">Equity</h3>
            <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
              <p className="flex justify-between"><span>Common Stock:</span> <span>{formatLargeMonetaryNumber(commonStock)}</span></p>
              <p className="flex justify-between"><span>Preferred Stock:</span> <span>{formatLargeMonetaryNumber(preferredStock)}</span></p>
              <p className="flex justify-between"><span>Retained Earnings:</span> <span>{formatLargeMonetaryNumber(retainedEarnings)}</span></p>
              <p className="flex justify-between"><span>Accumulated Other Comprehensive Income:</span> <span>{formatLargeMonetaryNumber(accumulatedOtherComprehensiveIncomeLoss)}</span></p>
              <p className="flex justify-between"><span>Other Stockholders Equity:</span> <span>{formatLargeMonetaryNumber(othertotalStockholdersEquity)}</span></p>
              <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
              <p className="flex justify-between font-bold"><span>Total Stockholders Equity:</span> <span>{formatLargeMonetaryNumber(totalStockholdersEquity)}</span></p>
            </div>
          </div>
        </div>
      </div>

      {/* 5. Key Ratios / Health Metrics */}
      <div className="mt-6 bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
        <h2 className="text-xl font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Key Financial Health Metrics</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-gray-50">
            <h3 className="text-lg font-medium mb-2 text-neutral-100 light-mode:text-neutral-900">Current Ratio</h3>
            <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatRatio(currentRatio)}</p>
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Measures ability to pay short-term obligations</p>
          </div>
          <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-gray-50">
            <h3 className="text-lg font-medium mb-2 text-neutral-100 light-mode:text-neutral-900">Debt-to-Equity Ratio</h3>
            <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatRatio(debtToEquityRatio)}</p>
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Measures financial leverage</p>
          </div>
          <div className="p-4 rounded-lg bg-neutral-700 light-mode:bg-gray-50">
            <h3 className="text-lg font-medium mb-2 text-neutral-100 light-mode:text-neutral-900">Cash to Total Assets</h3>
            <p className="text-2xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatRatio(cashToTotalAssets)}</p>
            <p className="text-sm text-neutral-400 light-mode:text-gray-600">Measures liquidity position</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BalanceSheetPage; 