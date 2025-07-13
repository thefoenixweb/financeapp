import React, { useEffect, useState } from 'react';
import { CompanyIncomeStatement } from '../../../company';
import Spinner from '../../Components/Spinner/Spinner.tsx';
import { formatLargeMonetaryNumber, formatRatio, formatLargeNonMonetaryNumber } from '../../Helpers/NumberFormatting.tsx';
import { useCompany } from '../../Context/CompanyContext';
import { getIncomeStatement } from '../../api';
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

const IncomeStatementPage: React.FC = (props: Props) => {
  const { ticker, companyData } = useCompany();
  const [incomeStatementData, setIncomeStatementData] = useState<CompanyIncomeStatement | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchIncomeStatement = async () => {
      if (!ticker) return;
      
      try {
        setIsLoading(true);
        setError(null);
        const result = await getIncomeStatement(ticker);
        if (result && result.length > 0) {
          setIncomeStatementData(result[0]);
        } else {
          setError('No income statement data available');
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch income statement data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchIncomeStatement();
  }, [ticker]);

  if (isLoading) {
    return <Spinner />;
  }

  if (error || !incomeStatementData || !companyData) {
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
    revenue,
    netIncome,
    netIncomeRatio,
    eps,
    epsdiluted,
    grossProfit,
    grossProfitRatio,
    operatingIncome,
    operatingIncomeRatio,
    ebitda,
    ebitdaratio,
    costOfRevenue,
    sellingGeneralAndAdministrativeExpenses,
    researchAndDevelopmentExpenses,
    otherExpenses,
    operatingExpenses,
    costAndExpenses,
    interestIncome,
    interestExpense,
    depreciationAndAmortization,
    totalOtherIncomeExpensesNet,
    incomeBeforeTax,
    incomeBeforeTaxRatio,
    incomeTaxExpense,
    weightedAverageShsOut,
    weightedAverageShsOutDil
  } = incomeStatementData;

  // Chart Data for Revenue vs. Net Income
  const revenueNetIncomeData = {
    labels: ['Revenue', 'Net Income', 'Gross Profit', 'Operating Income'],
    datasets: [
      {
        label: 'Amount',
        data: [revenue, netIncome, grossProfit, operatingIncome],
        backgroundColor: ['rgba(75, 192, 192, 0.6)', 'rgba(153, 102, 255, 0.6)', 'rgba(255, 159, 64, 0.6)', 'rgba(54, 162, 235, 0.6)'],
        borderColor: ['rgba(75, 192, 192, 1)', 'rgba(153, 102, 255, 1)', 'rgba(255, 159, 64, 1)', 'rgba(54, 162, 235, 1)'],
        borderWidth: 1,
      },
    ],
  };

  const revenueNetIncomeOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Revenue vs. Net Income' },
    },
  };

  // Chart Data for Expense Breakdown (Pie Chart)
  const expenseBreakdownData = {
    labels: [
      'Cost of Revenue',
      'SG&A Expenses',
      'R&D Expenses',
      'Other Expenses',
    ],
    datasets: [
      {
        label: 'Expenses',
        data: [
          costOfRevenue,
          sellingGeneralAndAdministrativeExpenses,
          researchAndDevelopmentExpenses,
          otherExpenses,
        ],
        backgroundColor: [
          'rgba(255, 99, 132, 0.6)',
          'rgba(54, 162, 235, 0.6)',
          'rgba(255, 206, 86, 0.6)',
          'rgba(75, 192, 192, 0.6)',
        ],
        borderColor: [
          'rgba(255, 99, 132, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
        ],
        borderWidth: 1,
      },
    ],
  };

  const expenseBreakdownOptions = {
    responsive: true,
    plugins: {
      legend: { position: 'top' as const },
      title: { display: true, text: 'Operational Expenses Breakdown' },
    },
  };

  return (
    <div className="p-6">
      {/* 1. Top Header: Company & Report Identification */}
      <div className="bg-neutral-800 p-4 rounded-lg shadow mb-6 flex flex-wrap justify-between items-center light-mode:bg-white">
        <div>
          <h2 className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{symbol} <span className="text-neutral-400 text-base light-mode:text-gray-600">({companyData.companyName})</span></h2>
          <p className="text-sm text-neutral-400 light-mode:text-gray-500">Central Index Key: {cik}</p>
        </div>
        <div className="text-right">
          <p className="text-lg font-semibold text-neutral-100 light-mode:text-neutral-900">Report Period: {period} {calendarYear}</p>
          <p className="text-neutral-400 light-mode:text-neutral-900">Report Date: {date}</p>
          <p className="text-neutral-400 light-mode:text-neutral-900">Filing Date: {fillingDate}</p>
          <p className="text-neutral-400 light-mode:text-neutral-900">Accepted Date: {acceptedDate}</p>
          <p className="text-neutral-400 light-mode:text-neutral-900">Currency: {reportedCurrency}</p>
          {finalLink && (
            <a href={finalLink} target="_blank" rel="noopener noreferrer" className="text-primary-gold hover:underline text-sm light-mode:text-blue-500 light-mode:hover:text-blue-700">
              Source Document <i className="fas fa-external-link-alt"></i>
            </a>
          )}
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* 2. Main KPI Block: The "Money Story" (Top-Left Section) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">The Money Story</h2>
          <div className="grid grid-cols-2 gap-4">
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Revenue</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(revenue)}</p>
            </div>
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Net Income</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(netIncome)}</p>
              <p className="text-xs text-neutral-500 light-mode:text-gray-500">Ratio: {formatRatio(netIncomeRatio)}%</p>
            </div>
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">EPS</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">${eps?.toFixed(2)}</p>
              <p className="text-xs text-neutral-500 light-mode:text-gray-500">Diluted: ${epsdiluted?.toFixed(2)}</p>
            </div>
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Gross Profit</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(grossProfit)}</p>
              <p className="text-xs text-neutral-500 light-mode:text-gray-500">Ratio: {formatRatio(grossProfitRatio)}%</p>
            </div>
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">Operating Income</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(operatingIncome)}</p>
              <p className="text-xs text-neutral-500 light-mode:text-gray-500">Ratio: {formatRatio(operatingIncomeRatio)}%</p>
            </div>
            <div className="bg-neutral-700 p-4 rounded-lg light-mode:bg-gray-100">
              <p className="text-sm text-neutral-400 light-mode:text-gray-600">EBITDA</p>
              <p className="text-xl font-bold text-neutral-100 light-mode:text-neutral-900">{formatLargeMonetaryNumber(ebitda)}</p>
              <p className="text-xs text-neutral-500 light-mode:text-gray-500">Ratio: {formatRatio(ebitdaratio)}%</p>
            </div>
          </div>
          <div className="mt-6">
            <Bar data={revenueNetIncomeData} options={revenueNetIncomeOptions} />
          </div>
        </div>

        {/* 3. Expense Breakdown: Where the Money Goes (Top-Right Section) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Operational Expenses Breakdown</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Cost of Revenue:</span> <span>{formatLargeMonetaryNumber(costOfRevenue)}</span></p>
            <p className="flex justify-between"><span>SG&A Expenses:</span> <span>{formatLargeMonetaryNumber(sellingGeneralAndAdministrativeExpenses)}</span></p>
            <p className="flex justify-between"><span>R&D Expenses:</span> <span>{formatLargeMonetaryNumber(researchAndDevelopmentExpenses)}</span></p>
            <p className="flex justify-between"><span>Other Expenses:</span> <span>{formatLargeMonetaryNumber(otherExpenses)}</span></p>
            <hr className="my-2 border-neutral-700 light-mode:border-neutral-300" />
            <p className="flex justify-between font-bold"><span>Total Operating Expenses:</span> <span>{formatLargeMonetaryNumber(operatingExpenses)}</span></p>
            <p className="flex justify-between font-bold"><span>Total Cost and Expenses:</span> <span>{formatLargeMonetaryNumber(costAndExpenses)}</span></p>
          </div>
          <div className="mt-6">
            <Pie data={expenseBreakdownData} options={expenseBreakdownOptions} />
          </div>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 mt-6">
        {/* 4. Income & Tax Details (Middle-Left Section) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Non-Operating & Tax Items</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Interest Income:</span> <span>{formatLargeMonetaryNumber(interestIncome)}</span></p>
            <p className="flex justify-between"><span>Interest Expense:</span> <span>{formatLargeMonetaryNumber(interestExpense)}</span></p>
            <p className="flex justify-between"><span>Depreciation & Amortization:</span> <span>{formatLargeMonetaryNumber(depreciationAndAmortization)}</span></p>
            <p className="flex justify-between"><span>Total Other Income/Expenses Net:</span> <span>{formatLargeMonetaryNumber(totalOtherIncomeExpensesNet)}</span></p>
            <p className="flex justify-between"><span>Income Before Tax:</span> <span>{formatLargeMonetaryNumber(incomeBeforeTax)}</span></p>
            <p className="flex justify-between"><span>Income Before Tax Ratio:</span> <span>{formatRatio(incomeBeforeTaxRatio)}%</span></p>
            <p className="flex justify-between"><span>Income Tax Expense:</span> <span>{formatLargeMonetaryNumber(incomeTaxExpense)}</span></p>
          </div>
        </div>

        {/* 5. Shareholder Information (Middle-Right Section) */}
        <div className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-lg font-semibold mb-4 text-neutral-100 light-mode:text-neutral-900">Share Details</h2>
          <div className="space-y-2 text-neutral-100 light-mode:text-neutral-900">
            <p className="flex justify-between"><span>Weighted Avg. Shares Out:</span> <span>{formatLargeNonMonetaryNumber(weightedAverageShsOut)}</span></p>
            <p className="flex justify-between"><span>Weighted Avg. Shares Out Diluted:</span> <span>{formatLargeNonMonetaryNumber(weightedAverageShsOutDil)}</span></p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default IncomeStatementPage; 